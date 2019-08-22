namespace SuperMario
{
    class EnemyPushDownCommand : ICommand
    {
        private IEnemy enemy;
        private int delta;

        public EnemyPushDownCommand(IEnemy gameObject, int deltaY)
        {
            enemy = gameObject;
            delta = deltaY;
        }

        public void Execute()
        {
            enemy.PushDown(delta);
        }
    }
}
