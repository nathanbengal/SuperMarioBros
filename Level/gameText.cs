using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public static class GameText
    {
        private static int xOffSet;
        private static int yOffSet;

        /*
         * Uses percentages to draw standard first player text accross the screen.
         * moves with the camera.
         */
        public static void DrawStandardFPText(SpriteBatch spriteBatch, SpriteFont font)
        {
            xOffSet = GlobalVariables.CameraXPos + (int)(0.05 * GlobalVariables.CameraWidth);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.02);
            spriteBatch.DrawString(font, "Mario", new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(0.55 * GlobalVariables.CameraWidth);
            spriteBatch.DrawString(font, "World", new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(0.85 * GlobalVariables.CameraWidth);
            spriteBatch.DrawString(font, "Time", new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.05);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.08);
            spriteBatch.DrawString(font, convertScore(), new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.30);
            Coin coin = new Coin(xOffSet, yOffSet);
            coin.Draw();
            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.325);
            spriteBatch.DrawString(font, (convertCoinCount()), 
                                                    new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.575);
            spriteBatch.DrawString(font, "1-1", new Vector2(xOffSet, yOffSet), Color.White);

            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.86);
            spriteBatch.DrawString(font, GlobalVariables.GameTime.ToString(), 
                                                    new Vector2(xOffSet, yOffSet), Color.White);

        }

        public static void DrawDeathScreenText(SpriteBatch spriteBatch, SpriteFont font)
        {
            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.46);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.45);
            Mario staticMario = new Mario(xOffSet, yOffSet);
            staticMario.Draw();

            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.50);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.45);
            string lifeCount = "x "+GlobalVariables.FirstPlayerLives.ToString();
            spriteBatch.DrawString(font, lifeCount, new Vector2(xOffSet, yOffSet), Color.White);
        }

        public static void PauseScreenText(SpriteBatch spriteBatch, SpriteFont font)
        {
            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.50);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.50);

            spriteBatch.DrawString(font, "PAUSED", new Vector2(xOffSet, yOffSet), Color.White);
        }

        public static void GameOverScreenText(SpriteBatch spriteBatch, SpriteFont font)
        {
            xOffSet = GlobalVariables.CameraXPos + (int)(GlobalVariables.CameraWidth * 0.43);
            yOffSet = (int)(GlobalVariables.CameraHeight * 0.475);

            spriteBatch.DrawString(font, "GAMEOVER", new Vector2(xOffSet, yOffSet), Color.Red);
        }

        private static String convertScore()
        {
            if (GlobalVariables.Score < 10)
            {
                return ("00000" + GlobalVariables.Score.ToString());
            }
            else if (GlobalVariables.Score < 100)
            {
                return ("0000" + GlobalVariables.Score.ToString());
            }
            else if (GlobalVariables.Score < 1000)
            {
                return ("000" + GlobalVariables.Score.ToString());
            }
            else if (GlobalVariables.Score < 10000)
            {
                return ("00" + GlobalVariables.Score.ToString());
            }
            else if (GlobalVariables.Score < 100000)
            {
                return ("0" + GlobalVariables.Score.ToString());
            }
            else
            {
                return GlobalVariables.Score.ToString();
            }
        }

        private static String convertCoinCount()
        {
            if (GlobalVariables.CoinCount < 10)
            {
                return ("x0" + GlobalVariables.CoinCount.ToString());
            }
            else
            {
                return "x" + GlobalVariables.CoinCount.ToString();
            }
        }
    }
}