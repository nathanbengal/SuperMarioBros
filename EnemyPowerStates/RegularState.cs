namespace SuperMario
{
    class RegularState : IEnemyPowerState
    {
        private IEnemy enemy;

        public RegularState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public IEnemyPowerState Damage()
        {
            int offset = SpriteFactory.Instance.CreateEnemyRegularSprite(enemy).MaxHeight;
            offset -= SpriteFactory.Instance.CreateRegularEnemyDeadSprite(enemy).MaxHeight;
            enemy.YCoordinate += offset;
            enemy.Sprite = SpriteFactory.Instance.CreateRegularEnemyDeadSprite(enemy);
            enemy.Physics = new DeadPhysics(enemy.XCoordinate, enemy.YCoordinate);
            return new DeadState();
        }

        public IEnemyPowerState JumpShroom()
        {
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyJumpSprite(enemy);
            enemy.Physics = new JumpPhysics(enemy.XCoordinate, enemy.YCoordinate);
            enemy.AI = new JumpAI();
            return new JumpState(enemy);
        }

        public IEnemyPowerState Mushroom()
        {
            enemy.YCoordinate -= SpriteFactory.Instance.CreateEnemyRegularSprite(enemy).MaxHeight;
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyBigSprite(enemy);
            enemy.AI = new BigAI();
            return new MushroomState(enemy);
        }

        public IEnemyPowerState Star()
        {
            //todo
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyStarSprite(enemy);
            enemy.Physics = new EnemyStarPhysics(enemy.XCoordinate, enemy.YCoordinate);
            enemy.AI = new StarAI();
            return new StarState();
        }
    }
}
