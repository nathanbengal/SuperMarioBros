namespace SuperMario
{
    class MushroomState : IEnemyPowerState
    {
        private IEnemy enemy;

        public MushroomState(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public IEnemyPowerState Damage()
        {
            //todo
            enemy.YCoordinate += SpriteFactory.Instance.CreateEnemyRegularSprite(enemy).MaxHeight;
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyRegularSprite(enemy);
            enemy.AI = new RegularAI();
            return new RegularState(enemy);
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
            //todo
            enemy.Sprite = SpriteFactory.Instance.CreateEnemyStarSprite(enemy);
            enemy.Physics = new EnemyStarPhysics(enemy.XCoordinate, enemy.YCoordinate);
            enemy.AI = new StarAI();
            return new StarState();
        }
    }
}
