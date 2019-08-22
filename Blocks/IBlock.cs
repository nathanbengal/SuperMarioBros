namespace SuperMario
{
    public interface IBlock
    {
        int Height { get; }
        int Width { get; }
        int XCoordinate { get; set; }

        int YCoordinate { get; set; }

        void Bump();
        void Update();
        void Draw();
    }
}
