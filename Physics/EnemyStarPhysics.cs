namespace SuperMario
{
    class EnemyStarPhysics : IEnemyPhysics
    {
        private int xCoordinate;
        private int yCoordinate;
        private int deltaY;
        private float yVelocity;
        private bool onGround;

        private readonly int X_SPEED = 3;
        private readonly float MAX_FALLSPEED = 11.0f;
        private float GRAVITY = 0.98f;
        private readonly float JUMP_SPEED = -18.0f;

        public EnemyStarPhysics(int x, int y)
        {
            yVelocity = 0.0f;
            xCoordinate = x;
            yCoordinate = y;
            GRAVITY = 0.98f;
        }

        public int[] GetPosition
        {
            get
            {
                //Will always be x Coordinate in 0 position
                //yCoordinate in 1 position of array.
                //Temporary until better system can be setup.
                int[] position = new int[2];
                position[0] = xCoordinate;
                position[1] = yCoordinate;
                return position;
            }
        }

        public void Left()
        {
            xCoordinate -= X_SPEED;
        }

        public void Right()
        {
            xCoordinate += X_SPEED;
        }

        public void LeftRun()
        {

        }

        public void RightRun()
        {

        }

        public void PushUp(int delta)
        {
            yCoordinate -= delta;
            yVelocity = 0.0f;
            onGround = true;
        }

        public void PushDown(int delta)
        {
            yCoordinate += delta;
            yVelocity = 0.0f;
        }

        public void PushRight(int delta)
        {
            xCoordinate += delta;
        }

        public void PushLeft(int delta)
        {
            xCoordinate -= delta;
        }

        public void Update()
        {
            yVelocity += GRAVITY;
            if (yVelocity >= MAX_FALLSPEED)
            {
                yVelocity = MAX_FALLSPEED;
            }
            deltaY = (int)((2.0f * yVelocity + GRAVITY) / 2.0f);
            yCoordinate += deltaY;
        }

        public void Jump()
        {
            if (onGround)
            {
                onGround = false;
                yVelocity = JUMP_SPEED;
            }
        }
    }
}
