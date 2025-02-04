namespace GameOfLife.Interfaces
{
    public interface ICell
    {
        bool NextState(int liveNeighbours);
        bool IsAlive { get; }
        int X { get; }
        int Y { get; }
    }
}
