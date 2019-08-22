namespace SuperMario
{
    class DeadPhysics : IEnemyPhysics
    {
        private int xCoordinate;
        private int yCoordinate;

        public DeadPhysics(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
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
        }

        public void Right()
        {
        }

        public void PushUp(int delta)
        {
        }

        public void PushDown(int delta)
        {
        }

        public void PushRight(int delta)
        {
        }

        public void PushLeft(int delta)
        {
        }

        public void LeftRun()
        {

        }

        public void RightRun()
        {

        }

        public void Update()
        {
        }
        public void Jump() { }
    }
}
