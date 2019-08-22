namespace SuperMario
{
    class EnemyLeftCommand : ICommand
    {
        private IEnemy enemy;

        public EnemyLeftCommand(IEnemy gameObject)
        {
            enemy = gameObject;
        }
        public void Execute()
        {
            enemy.Left();
        }
    }
}
