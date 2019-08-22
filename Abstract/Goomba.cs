namespace SuperMario
{
    class Goomba : AbstractEnemy, IGameObject, IEnemy
    {
        public Goomba(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            sprite = SpriteFactory.Instance.CreateGoombaSprite();
            //sprite = SpriteFactory.Instance.CreateBigGoombaSprite();
            width = sprite.MaxWidth;
            height = sprite.MaxHeight;
            movementState = new EnemyLeftMovementState();
            physics = new RegularPhysics(xCoordinate, yCoordinate);
            powerState = new RegularState(this);
            ai = new RegularAI();
            immuneTimer = 0;
            immune = false;

        }
    }
}
