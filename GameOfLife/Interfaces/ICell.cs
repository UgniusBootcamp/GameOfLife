namespace GameOfLife.Interfaces
{
    public interface ICell
    {
        bool IsAlive { get; }
        int X { get; }
        int Y { get; }
    }
}
