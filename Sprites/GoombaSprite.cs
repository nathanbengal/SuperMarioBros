using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class GoombaSprite : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private SpriteBatch spriteBatch;
        public GoombaSprite(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture)
        {
            sourceRectangle = new Rectangle(0, 0, 17, 24);
            destinationRectangle = new Rectangle(400, 240, 30, 80);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            return;
        }
    }
}

