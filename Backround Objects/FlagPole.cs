namespace SuperMario
{
    public class FlagPole : IGameObject
    {
        private ISprite sprite;
        //private ISprite flag;
        private bool endOfLevel;
        private int x;
        private int y;
        private int width;
        private int height;

        public FlagPole(int x, int y)
        {
            this.x = x;
            this.y = y;
            sprite = SpriteFactory.Instance.CreateFlagPoleSprite();
            //flag = new Flag(6896, 97);
            //flag = SpriteFactory.Instance.CreateFlagSprite();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
            endOfLevel = false;
            //flag = new Flag(6896, 97);
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

        public bool FlagDescend
        {
            get
            {
                return endOfLevel;
            }
            set
            {
                endOfLevel = value;
            }
        }

        public void Draw()
        {
            sprite.Draw(x, y);
        }

        public void Update()
        {
        }
    }
}
