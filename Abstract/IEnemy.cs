namespace SuperMario
{
    public interface IEnemy
    {
        int XCoordinate { get; }
        int YCoordinate { get; set; }
        int Height { get; }
        int Width { get; }
        bool Immune{ get; }
        IEnemyPhysics Physics { get; set; }
        ISprite Sprite { get; set; }
        IAI AI { get; set; }
        IEnemyMovementState MovementState { get; }
        IEnemyPowerState Power { get; }

        void BecomeImmune();
        void Left();
        void Right();
        void Jump();
        void RightRun();
        void LeftRun();
        void PushUp(int delta);
        void PushDown(int delta);
        void PushRight(int delta);
        void PushLeft(int delta);

        void Stomp();
        void Mushroom();
        void JumpShroom();
        void Star();
        

    }
}
