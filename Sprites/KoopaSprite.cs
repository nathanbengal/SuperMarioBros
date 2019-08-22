using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class KoopaSprite : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private SpriteBatch spriteBatch;
        public KoopaSprite(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture)
        {
            sourceRectangle = new Rectangle(175, 0, 28, 25);
            destinationRectangle = new Rectangle(400, 240, 40, 65);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            return;
        }
    }
}

