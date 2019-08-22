namespace SuperMario
{
    class EnemyLeftMovementState : IEnemyMovementState
    {
        public IEnemyMovementState Left()
        {
            return this;
        }

        public IEnemyMovementState Right()
        {
            return new EnemyRightMovementState();
        }
    }
}
