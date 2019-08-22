namespace SuperMario
{
    class EnemyPushRightCommand : ICommand
    {
        private IEnemy enemy;
        private int delta;

        public EnemyPushRightCommand(IEnemy gameObject, int deltaY)
        {
            enemy = gameObject;
            delta = deltaY;
        }

        public void Execute()
        {
            enemy.PushRight(delta);
        }
    }
}
