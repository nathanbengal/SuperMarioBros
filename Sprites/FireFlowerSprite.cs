using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class FireFlowerSprite : ISprite
    {
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private SpriteBatch spriteBatch;
        public FireFlowerSprite(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public void Draw(Texture2D texture)
        {
            sourceRectangle = new Rectangle(150, 62, 20, 20);
            destinationRectangle = new Rectangle(400, 240, 45, 60);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public void Update()
        {
            return;
        }
    }
}

