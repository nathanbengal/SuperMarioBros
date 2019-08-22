using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class CoinSprite : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private SpriteBatch spriteBatch;
        public CoinSprite(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture)
        {
            sourceRectangle = new Rectangle(120, 95, 17, 17);
            destinationRectangle = new Rectangle(400, 240, 45, 60);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            return;
        }
    }
}

