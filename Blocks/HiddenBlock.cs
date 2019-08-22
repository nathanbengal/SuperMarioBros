/* Authors: Nathan Bangal
 * Version: 2.1
 * Description: Hidden Block Controls
 */
namespace SuperMario
{
    public class HiddenBlock : IGameObject
    {
        private ISprite sprite;
        private int x;
        private int y;
        private int width;
        private int height;

        public HiddenBlock(int x, int y)
        {
            sprite = SpriteFactory.Instance.CreateEmptyBlockSprite();
            this.x = x;
            this.y = y;
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }
        public int XCoordinate
        {
            get
            {
                return this.x;
            }
        }

        public int YCoordinate
        {
            get
            {
                return this.y;
            }
        }

        public void Draw()
        {
            sprite.Draw(x, y);
        }

        public void Reset()
        {
            sprite = SpriteFactory.Instance.CreateEmptyBlockSprite();
        }

        public void Update()
        {
            sprite.Update();
        }
    }
}
