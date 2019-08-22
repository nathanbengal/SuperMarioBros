namespace SuperMario
{
    class CameraManager
    {
        private Camera camera;
        private IGameObject player;
        private int xCoordinate;

        public CameraManager(Mario player, Camera camera)
        {
            this.camera = camera;
            this.player = player;
            this.xCoordinate = 0;
        }

        public void Update()
        {
            int halfWidth = (camera.Width / 2);
            if ((player.XCoordinate + camera.XPos) > halfWidth)
            {
                camera.XPos = -player.XCoordinate + halfWidth;
                xCoordinate = player.XCoordinate-halfWidth;
                //camera.YPos = -player.YCoordinaddddte + halfHeight;
            }
            
            GlobalVariables.CameraXPos = xCoordinate;
        }
    }
}
