using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    class Camera
    {
        private SpriteBatch spriteBatch;
        private SpriteFont textFont;
        private int xPos;
        private int width = GlobalVariables.CameraWidth;

        public Camera(SpriteBatch spriteBatch, SpriteFont newFont)
        {
            this.spriteBatch = spriteBatch;
            this.textFont = newFont;
        }

        public int XPos
        {
            set
            {
                xPos = value;
            }
            get
            {
                return xPos;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public void Begin()
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, null, null, null, null, Matrix.CreateTranslation(xPos, 0, 0));
        }

        public void End()
        {
            spriteBatch.End();
        }
        public void DrawText()
        {
            //Vector2 pos = new Vector2(GlobalVariables.CameraXPos, GlobalVariables.CameraYPos);
            //spriteBatch.DrawString(textFont, "Ya Done Died. Testing. Testing 1,2,3", pos, Color.White);
            if (GlobalVariables.GameOver)
            {
                GameText.GameOverScreenText(spriteBatch, textFont);
            }
            else if (GlobalVariables.ShowBlackScreen)
            {
                GameText.DrawDeathScreenText(spriteBatch, textFont);
            }
            else if (GlobalVariables.Paused)
            {
                GameText.DrawStandardFPText(spriteBatch, textFont);
                GameText.PauseScreenText(spriteBatch, textFont);
            }
            else
            {
                GameText.DrawStandardFPText(spriteBatch, textFont);
            }
        }
    }
}
