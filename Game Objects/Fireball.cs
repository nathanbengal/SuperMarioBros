namespace SuperMario
{
    class FireBall : IGameObject
    {
        private ISprite sprite;
        private int x;
        private int y;
        private int width;
        private int height;
        private bool right;

        public FireBall(int x, int y, bool right)
        {
            this.x = x;
            this.y = y;
            sprite = SpriteFactory.Instance.CreateFireBallSprite();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
            this.right = right;
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

        public void Update()
        {
            if (right)
            {
                x += 10;
            }
            else
            {
                x -= 10;
            }
            
            sprite.Update();
        }
    }
}
