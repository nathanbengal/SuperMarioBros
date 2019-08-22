/* Authors: Nathan Bangal
 * Version: 2.1
 * Description: Question Block
 * Object
 */

namespace SuperMario
{
    public class ItemBlock : IGameObject, IBlock
    {
        private ISprite sprite;
        private int x;
        private int y;
        private int width;
        private int height;

        public ItemBlock(int x, int y)
        {
            sprite = SpriteFactory.Instance.CreateQuestionBlockSprite();
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
            set { }
        }

        public int YCoordinate
        {
            get
            {
                return this.y;
            }
            set { }
        }
        public void ChangeToUsed()
        {
            sprite = SpriteFactory.Instance.CreateUsedBlockSprite();
        }

        public void Reset()
        {
            sprite = SpriteFactory.Instance.CreateQuestionBlockSprite();
        }

        public void Draw()
        {
            sprite.Draw(x, y);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Bump() { }
    }
}
