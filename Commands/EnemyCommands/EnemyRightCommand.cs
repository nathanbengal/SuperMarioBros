namespace SuperMario
{
    class EnemyRightCommand : ICommand
    {
        private IEnemy enemy;

        public EnemyRightCommand(IEnemy gameObject)
        {
            enemy = gameObject;
        }
        public void Execute()
        {
            enemy.Right();
        }
    }
}
