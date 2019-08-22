using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMario
{
    class CollisionDetector
    {
        private Rectangle result;
        private int X;
        private int Y;
        private Rectangle Instigator;
        private Rectangle Receiver;
        private int dynamicObjectsCount;
        private List<CollisionObject> CollisionInformation;

        private const int   LEFT = 0,
                            RIGHT = 1,
                            TOP = 2,
                            BOTTOM = 3;
            
        private CollisionObject CInfo;
        public CollisionDetector()
        {
            CollisionInformation = new List<CollisionObject>();
        }
        List<Rectangle> staticRectangles = new List<Rectangle>();
        List<Rectangle> dynamicRectangles = new List<Rectangle>();
        //public List<Tuple<IGameObject, IGameObject, ICollision>> CheckCollisions2(List<IGameObject> staticObjects, List<IGameObject> dynamicObjects)
        //{
        public List<CollisionObject> CheckCollision(Dictionary<int, List<IGameObject>> staticObjects, List<IGameObject> dynamicObjects)
        {
            staticRectangles.Clear();
            dynamicRectangles.Clear();
            /* Place all dyanmic game objects' hit boxes into a list so they don't have to be repeatedly calculated */
            foreach (IGameObject dynamicObject in dynamicObjects)
            {
                dynamicRectangles.Add(new Rectangle(dynamicObject.XCoordinate, dynamicObject.YCoordinate, dynamicObject.Width, dynamicObject.Height));
            }
            /* Calculates counts of lists one time rather than repeatedly in the while conditions */
            dynamicObjectsCount = dynamicObjects.Count;
            CollisionInformation.Clear();

            int i = 0;
            while (i < dynamicObjectsCount)
            {
                Instigator = dynamicRectangles[i];
                int j = i + 1;
                while (j < dynamicObjectsCount)
                {
                    //Receiver = new Rectangle(dynamicObjects[j].XCoordinate, dynamicObjects[j].YCoordinate, dynamicObjects[j].Width, dynamicObjects[j].Height);
                    Receiver = dynamicRectangles[j];
                    /* test each dyanmic object against all dynamic objects found lower than itself in the list  */
                    if (Instigator.Intersects(Receiver))
                    {
                        result = Rectangle.Intersect(Instigator, Receiver);

                        X = result.Right - result.Left;
                        Y = result.Bottom - result.Top;
                        if (X > Y)
                        {
                            if (Instigator.Top < Receiver.Top)
                            {
                                CInfo = new CollisionObject(dynamicObjects[i], dynamicObjects[j], TOP);
                                CInfo.CrossIntersection = result;
                            }
                            else
                            {
                                CInfo = new CollisionObject(dynamicObjects[i], dynamicObjects[j], BOTTOM);
                                CInfo.CrossIntersection = result;
                            }
                        }
                        else
                        {
                            if (Instigator.Right < Receiver.Right)
                            {
                                CInfo = new CollisionObject(dynamicObjects[i], dynamicObjects[j], RIGHT);
                                CInfo.CrossIntersection = result;
                            }
                            else
                            {
                                CInfo = new CollisionObject(dynamicObjects[i], dynamicObjects[j], LEFT);
                                CInfo.CrossIntersection = result;
                            }
                        }
                        CollisionInformation.Add(CInfo);
                    }
                    j++;
                }
                i++;

            }



            foreach(IGameObject Dynamic in dynamicObjects)
            {
                Instigator = new Rectangle(Dynamic.XCoordinate, Dynamic.YCoordinate, Dynamic.Width, Dynamic.Height);
                int DynamicBlock = Dynamic.XCoordinate / 32;
                if (staticObjects.ContainsKey(DynamicBlock - 2))
                {
                    CollisionInformation.AddRange(CheckStatic(Dynamic, staticObjects[DynamicBlock - 2]));
                }
                if (staticObjects.ContainsKey(DynamicBlock - 1))
                {
                    CollisionInformation.AddRange(CheckStatic(Dynamic, staticObjects[DynamicBlock - 1]));
                }
                if (staticObjects.ContainsKey(DynamicBlock))
                {
                    CollisionInformation.AddRange(CheckStatic(Dynamic, staticObjects[DynamicBlock]));
                }
                if (staticObjects.ContainsKey(DynamicBlock + 1))
                {
                    CollisionInformation.AddRange(CheckStatic(Dynamic, staticObjects[DynamicBlock + 1]));
                }
                if (staticObjects.ContainsKey(DynamicBlock + 2))
                {
                    CollisionInformation.AddRange(CheckStatic(Dynamic, staticObjects[DynamicBlock + 2]));
                }
            }
            return CollisionInformation;
        }


        private List<CollisionObject> CheckStatic(IGameObject dynamicObject, List<IGameObject> staticList)
        {
            List<CollisionObject> Collisions = new List<CollisionObject>();

            foreach (IGameObject Static in staticList)
            {
                Receiver = new Rectangle(Static.XCoordinate, Static.YCoordinate, Static.Width, Static.Height); ;
                if (Instigator.Intersects(Receiver))
                {
                    result = Rectangle.Intersect(Instigator, Receiver);
                    X = result.Right - result.Left;
                    Y = result.Bottom - result.Top;
                    if (X > Y)
                    {
                        if (Instigator.Top < Receiver.Top)
                        {
                            CInfo = new CollisionObject(Static, dynamicObject, TOP);
                            CInfo.CrossIntersection = result;
                        }
                        else
                        {
                            CInfo = new CollisionObject(Static, dynamicObject, BOTTOM);
                            CInfo.CrossIntersection = result;
                        }
                    }
                    else
                    {
                        if (Instigator.Right < Receiver.Right)
                        {
                            CInfo = new CollisionObject(Static, dynamicObject, RIGHT);
                            CInfo.CrossIntersection = result;
                        }
                        else
                        {
                            CInfo = new CollisionObject(Static, dynamicObject, LEFT);
                            CInfo.CrossIntersection = result;
                        }
                    }
                    Collisions.Add(CInfo);
                }
            }



            return Collisions;
        }
    }
}