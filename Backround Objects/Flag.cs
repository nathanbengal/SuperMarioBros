namespace SuperMario
{
    class Flag : IGameObject
    {
        private ISprite sprite;
        private int x;
        private int y;
        private int width;
        private int height;

        public Flag(int x, int y)
        {
            this.x = x;
            this.y = y;
            sprite = SpriteFactory.Instance.CreateFlagSprite();
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
            set
            {
                this.y = value;
            }
        }

        public void Draw()
        {
           sprite.Draw(x, y);
        }

        public void Update()
        {
            if (GlobalVariables.FlagDescend)
                YCoordinate += GlobalVariables.FlagDescendSpeed;
        }
    }
}
