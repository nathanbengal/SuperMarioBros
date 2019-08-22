using System;
using System.Collections.Generic;
using System.Xml;

namespace SuperMario
{
    public sealed class Level : IDisposable
    {
        private static IGameObject staticPlayer;
        private IGameObject player;
        private Dictionary<int, List<IGameObject>> staticObjects = new Dictionary<int, List<IGameObject>>();
        private List<IGameObject> toBeRemoved = new List<IGameObject>();
        private List<IGameObject> toBeAdded = new List<IGameObject>();
        private List<IGameObject> backgroundObjects = new List<IGameObject>();
        private List<IGameObject> dynamicObjects = new List<IGameObject>();
        private XmlReader levelReader;
        private CollisionDetector collisionDetector = new CollisionDetector();
        private CollisionHandler handler;

        //Update to Second Conversion value
        private const int DELAY = 60;
        private int timerDelay;

        public Level()
        {
            timerDelay = 0;
        }
        
        public IGameObject Player
        {
            get
            {
                return player;
            }
        }

        public static IMario GetPlayer
        {
            get
            {
                return (IMario)staticPlayer;
            }
        }

        public void SetStaticPlayer()
        {
            staticPlayer = player;
        }

        public void LoadLevelContent(String fileName, MarioGame game)
        {
            levelReader = new XmlTextReader(fileName);
            levelReader.MoveToContent();
            Type[] ConstructorTypes = new Type[2];
            ConstructorTypes[0] = typeof(int);
            ConstructorTypes[1] = typeof(int);

            while (levelReader.ReadToFollowing("item"))
            {
                String MovementType;
                String ObjectType;
                Object[] Position = new Object[2];

                levelReader.ReadToDescendant("Type");
                levelReader.MoveToFirstAttribute();
                MovementType = levelReader.Value;
                levelReader.MoveToElement();
                levelReader.ReadToNextSibling("Object");
                levelReader.MoveToFirstAttribute();
                ObjectType = levelReader.Value;
                levelReader.MoveToElement();
                levelReader.ReadToNextSibling("Location");
                levelReader.MoveToFirstAttribute();
                Position[0] = Convert.ToInt32(levelReader.Value);
                levelReader.MoveToNextAttribute();
                Position[1] = Convert.ToInt32(levelReader.Value);

                IGameObject CurrentObject = (IGameObject)Type.GetType("SuperMario." + ObjectType).GetConstructor(ConstructorTypes).Invoke(Position);
                if (MovementType.Equals("Background"))
                {
                    backgroundObjects.Add(CurrentObject);
                }
                else if (MovementType.Equals("Dynamic"))
                {
                    dynamicObjects.Add(CurrentObject);
                }
                else
                {
                    int ListPos = CurrentObject.XCoordinate / GlobalVariables.BlockSize;
                    if (staticObjects.ContainsKey(ListPos))
                    {
                        staticObjects[ListPos].Add(CurrentObject);
                    }
                    else
                    {
                        staticObjects.Add(ListPos, new List<IGameObject>());
                        staticObjects[ListPos].Add(CurrentObject);

                    }
                }
                
                if (CurrentObject is Mario) 
                {
                    player = CurrentObject;
                }

            }
            //load collision dictionary once the level is loaded
            handler = new CollisionHandler(this, game);
        }

        public void Update()
        {
            foreach (IGameObject GameObject in backgroundObjects)
            {
                GameObject.Update();
            }
            foreach (List<IGameObject> List in staticObjects.Values)
            {
                foreach (IGameObject GameObject in List)
                {
                    GameObject.Update();
                }
            }
            foreach (IGameObject GameObject in dynamicObjects)
            {
                GameObject.Update();
            }



            foreach (IGameObject gameObject in toBeRemoved)
            {
                dynamicObjects.Remove(gameObject);
            }
            toBeRemoved.Clear();
            foreach (IGameObject gameObject in toBeAdded)
            {
                dynamicObjects.Insert(0, gameObject);

            }
            toBeAdded.Clear();
            List<CollisionObject> testList = collisionDetector.CheckCollision(staticObjects, dynamicObjects);
            handler.Handle(testList);
            timerDelay++;
            if(timerDelay >= DELAY && GlobalVariables.GameTime > 0)
            {
                timerDelay = 0;
                GlobalVariables.GameTime--;
                if (GlobalVariables.GameTime == GlobalVariables.SpeedUpTime)
                    MusicPlayer.EffectList("timewarming").Play();
            }
        }

        public void Draw()
        {
            foreach (IGameObject GameObject in backgroundObjects)
            {
                GameObject.Draw();
            }
            foreach (List<IGameObject> List in staticObjects.Values)
            {
                foreach (IGameObject GameObject in List)
                {
                    GameObject.Draw();
                }
            }
            foreach (IGameObject GameObject in dynamicObjects)
            {
                GameObject.Draw();
            }
        }

        public void Clear()
        {
            dynamicObjects.Clear();
            staticObjects.Clear();
            backgroundObjects.Clear();
        }

        public void MoveToBackground(IGameObject gameObject)
        {
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            if (staticObjects[ListPos].Contains(gameObject))
            {
                staticObjects[ListPos].Remove(gameObject);
                backgroundObjects.Add(gameObject);
            }
            if (dynamicObjects.Contains(gameObject))
            {
                dynamicObjects.Remove(gameObject);
                backgroundObjects.Add(gameObject);
            }
        }

        public void Delete(IGameObject gameObject)
        {
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            if (dynamicObjects.Contains(gameObject))
            {
                dynamicObjects.Remove(gameObject);
            }
            else if (staticObjects[ListPos].Contains(gameObject))
            {
                staticObjects[ListPos].Remove(gameObject);
            }
        }

        public void ReplaceWithUsed(IGameObject gameObject)
        {
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            staticObjects[ListPos].Remove(gameObject);
            staticObjects[ListPos].Add(new UsedBlock(gameObject.XCoordinate, gameObject.YCoordinate));

        }

        public void Swap(IGameObject oldObject, IGameObject newObject)
        {
            toBeAdded.Add(newObject);
            toBeRemoved.Add(oldObject);
        }

        public void ReplaceDynamicObject(IGameObject gameObject, IGameObject replacement)
        {
            if (dynamicObjects.Contains(gameObject))
            {
                dynamicObjects.Insert(0, replacement);
                dynamicObjects.Remove(gameObject);
            }
        }

        public void ReplaceStaticObject(IGameObject gameObject, IGameObject replacement)
        {
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            staticObjects[ListPos].Remove(gameObject);
            staticObjects[ListPos].Add(replacement);

        }

        public void SpawnCoin(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            int SpriteOffset = GlobalVariables.CoinOffset;
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;

            staticObjects[ListPos].Add(new Coin(gameObject.XCoordinate + SpriteOffset, gameObject.YCoordinate - OffsetBlockHeight));
        }

        public void SpawnExtraLifeMushroom(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            dynamicObjects.Add(new ExtraLifeMushroom(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }

        public void SpawnMushroom(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            dynamicObjects.Add(new Mushroom(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }
        public void SpawnGravityOrb(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            dynamicObjects.Add(new GravityOrb(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }

        public void SpawnFireFlower(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            staticObjects[ListPos].Add(new FireFlower(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }
        public void SpawnSuperCrown(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            int ListPos = gameObject.XCoordinate / GlobalVariables.BlockSize;
            staticObjects[ListPos].Add(new SuperCrown(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }

        public void SpawnStar(IGameObject gameObject)
        {
            /* These numbers are offset so the coin spawns on top of the block */
            int OffsetBlockHeight = GlobalVariables.BlockSize;
            dynamicObjects.Add(new Star(gameObject.XCoordinate, gameObject.YCoordinate - OffsetBlockHeight));
        }

        public void SpawnFireBall(IMario mario)
        {
            int XOffsetBlockHeight = GlobalVariables.FireballXOffset;
            int YOffsetBlockHeight = GlobalVariables.FireballYOffset;

            
            dynamicObjects.Add(new FireBall(mario.XCoordinate + XOffsetBlockHeight, mario.YCoordinate + YOffsetBlockHeight, mario.State is MarioRightAttackState));
        }

        //added to remove warning ca1001, never used
        public void Dispose()
        {
            levelReader.Dispose();
        }
    }
}
