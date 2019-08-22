namespace SuperMario
{
    class EnemyRightMovementState : IEnemyMovementState
    {
        public IEnemyMovementState Left()
        {
            return new EnemyLeftMovementState();
        }

        public IEnemyMovementState Right()
        {
            return this;
        }
    }
}
