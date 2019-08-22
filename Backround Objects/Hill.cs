namespace SuperMario
{
    class Hill : IGameObject
    {
        private ISprite sprite;
        private int x;
        private int y;
        private int width;
        private int height;

        public Hill(int x, int y)
        {
            this.x = x;
            this.y = y;
            sprite = SpriteFactory.Instance.CreateHillSprite();
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

        public void Update()
        {
            //this will eventually call some sort of physics class as well
            sprite.Update();
        }
    }
}
