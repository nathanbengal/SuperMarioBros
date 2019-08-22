namespace SuperMario
{
    class JumpState : IEnemyPowerState
    {
        private IEnemy enemy;

        public JumpState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public IEnemyPowerState Damage()
        {
            int offset = SpriteFactory.Instance.CreateEnemyRegularSprite(enemy).MaxHeight;
            offset -= SpriteFactory.Instance.CreateRegularEnemyDeadSprite(enemy).MaxHeight;
            enemy.YCoordinate += offset;
            enemy.Sprite = SpriteFactory.Instance.CreateJumpEnemyDeadSprite(enemy);
            enemy.Physics = new DeadPhysics(enemy.XCoordinate, enemy.YCoordinate);
            enemy.AI = new RegularAI();
            return new DeadState();
        }

        public IEnemyPowerState JumpShroom()
        {
            return this;
        }

        public IEnemyPowerState Mushroom()
        {
            return this;
        }

        public IEnemyPowerState Star()
        {
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyStarSprite(enemy);
            enemy.Physics = new EnemyStarPhysics(enemy.XCoordinate, enemy.YCoordinate);
            enemy.AI = new StarAI();
            return new StarState();
        }
    }
}
