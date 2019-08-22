/* Author: David Cordle
 * Updated: June 12th 2019
 * Version: 3.5
 * Description: Handles Star Mario
 * Drawing, including the changing colors
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace SuperMario
{
    class StarMachine : SpriteMachine
    {
        private int colorTimer;
        private int maxColors;
        private int linger;

        public StarMachine(SpriteBatch spriteBatch, String targetSprite) : base(spriteBatch, targetSprite)
        {
            //Gather and pass up the chain
            colorTimer = 0;
            maxColors = 8;
            linger = 6;
        }

        public override void Draw(int x, int y)
        {
            int CurrentFrame = time / lengthOfFrame;
            Rectangle DestinationRectangle = new Rectangle(x, y, 2 * widthArray[CurrentFrame], 2 * heightArray[CurrentFrame]);
            Color[] starColors = new Color[8];
            starColors[0] = Color.White;
            starColors[1] = Color.Red;
            starColors[2] = Color.Orange;
            starColors[3] = Color.Yellow;
            starColors[4] = Color.SeaGreen;
            starColors[5] = Color.SkyBlue;
            starColors[6] = Color.Gold;
            starColors[7] = Color.Violet;
            spriteBatch.Draw(texture, DestinationRectangle, sourceRectangles[CurrentFrame], starColors[colorTimer/linger]);
        }

        public override void Update()
        {
            time++;
            if (time >= (lengthOfFrame * numberOfFrames))
            {
                time = 0;
            }
            colorTimer++;
            if (colorTimer >= (linger * maxColors))
            {
                colorTimer = 0;
            }
        }
    }
}