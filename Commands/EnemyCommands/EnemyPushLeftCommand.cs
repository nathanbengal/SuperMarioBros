namespace SuperMario
{
    class EnemyPushLeftCommand : ICommand
    {
        private IEnemy enemy;
        private int delta;

        public EnemyPushLeftCommand(IEnemy gameObject, int deltaY)
        {
            enemy = gameObject;
            delta = deltaY;
        }

        public void Execute()
        {
            enemy.PushLeft(delta);
        }
    }
}
