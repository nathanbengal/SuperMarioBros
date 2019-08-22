using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SuperMario
{
    class SpriteMachine : ISprite, IDisposable
    {
        protected XmlReader reader = new XmlTextReader("SpriteInfo.xml");
        protected SpriteBatch spriteBatch;
        protected Texture2D texture;
        protected int lengthOfFrame = 10;
        protected int time = 0;
        protected int numberOfFrames;
        protected int[] xArray;
        protected int[] yArray;
        protected int[] widthArray;
        protected int[] heightArray;
        protected int maxWidth = 0;
        protected int maxHeight = 0;
        protected Rectangle[] sourceRectangles;
        protected static Dictionary<String, Texture2D> textureDictionary = new Dictionary<String, Texture2D>();

        public SpriteMachine(SpriteBatch spriteBatch, String targetSprite)
        {
            this.spriteBatch = spriteBatch;
            //finds correct sprite in info
            reader.MoveToContent();
            reader.ReadToFollowing(targetSprite);

            //sets up sprite 
            reader.MoveToFirstAttribute();
            numberOfFrames = Convert.ToInt32(reader.Value);
            reader.MoveToNextAttribute();
            texture = textureDictionary[reader.Value];
            reader.MoveToElement();

            //sets up arrays
            xArray = new int[numberOfFrames];
            yArray = new int[numberOfFrames];
            widthArray = new int[numberOfFrames];
            heightArray = new int[numberOfFrames];

            reader.ReadToDescendant("SourceRectangle");
            for (int i = 0; i < numberOfFrames; i++)
            {
                reader.MoveToFirstAttribute();
                xArray[i] = Convert.ToInt32(reader.Value);
                reader.MoveToNextAttribute();
                yArray[i] = Convert.ToInt32(reader.Value);
                reader.MoveToNextAttribute();
                widthArray[i] = Convert.ToInt32(reader.Value);
                reader.MoveToNextAttribute();
                heightArray[i] = Convert.ToInt32(reader.Value);
                reader.MoveToElement();
                reader.ReadToNextSibling("SourceRectangle");
                if (widthArray[i] > maxWidth)
                {
                    maxWidth = widthArray[i];
                }
                if (heightArray[i] > maxHeight)
                {
                    maxHeight = heightArray[i];
                }
            }
            //create sourceRectangles
            sourceRectangles = new Rectangle[numberOfFrames];
            for (int i = 0; i < numberOfFrames; i++)
            {
                sourceRectangles[i] = new Rectangle(xArray[i], yArray[i], widthArray[i], heightArray[i]);
            }
        }

        public int MaxHeight
        {
            get
            {
                return 2 * maxHeight;
            }
        }

        public int MaxWidth
        {
            get
            {
                return 2 * maxWidth;
            }
        }

        public static void LoadTextures(ContentManager content)
        {
            textureDictionary.Add("Mario", content.Load<Texture2D>("mario"));
            textureDictionary.Add("Items", content.Load<Texture2D>("Items"));
            textureDictionary.Add("Enemies", content.Load<Texture2D>("Enemies"));
            textureDictionary.Add("EnemiesBig", content.Load<Texture2D>("EnemiesBig"));
            textureDictionary.Add("Blocks", content.Load<Texture2D>("Blocks"));
            textureDictionary.Add("Blocks2", content.Load<Texture2D>("Blocks2"));
            textureDictionary.Add("Backround", content.Load<Texture2D>("Backround"));
            textureDictionary.Add("FlagCastle", content.Load<Texture2D>("FlagCastle"));
            textureDictionary.Add("MarioRight", content.Load<Texture2D>("ExtraMarioSprites"));
            textureDictionary.Add("MarioLeft", content.Load<Texture2D>("ExtraMarioFlip"));
            textureDictionary.Add("GravityOrb", content.Load<Texture2D>("GravityOrb"));
            textureDictionary.Add("SuperCrown", content.Load<Texture2D>("SuperCrown"));
        }

        public virtual void Draw(int x, int y)
        {
            int CurrentFrame = time / lengthOfFrame;
            Rectangle DestinationRectangle = new Rectangle(x, y, 2 * widthArray[CurrentFrame], 2 * heightArray[CurrentFrame]);
            spriteBatch.Draw(texture, DestinationRectangle, sourceRectangles[CurrentFrame], Color.White);
        }

        public virtual void Update()
        {
            time++;
            if (time >= (lengthOfFrame * numberOfFrames))
            {
                time = 0;
            }
        }

        //added to remove warning ca1001, never used
        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
