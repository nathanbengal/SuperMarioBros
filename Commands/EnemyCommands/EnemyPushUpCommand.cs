namespace SuperMario
{
    class EnemyPushUpCommand : ICommand
    {
        private IEnemy enemy;
        private int delta;

        public EnemyPushUpCommand(IEnemy gameObject, int deltaY)
        {
            enemy = gameObject;
            delta = deltaY;
        }

        public void Execute()
        {
            enemy.PushUp(delta);
        }
    }
}
