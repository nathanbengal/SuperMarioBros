namespace SuperMario
{
    public interface IEnemyPhysics
    {
        int[] GetPosition { get; }
        void Left();
        void Right();
        void LeftRun();
        void RightRun();
        void PushUp(int delta);
        void PushDown(int delta);
        void PushRight(int delta);
        void PushLeft(int delta);
        void Update();
        void Jump();
    }
}
