namespace GameOfLife.Interfaces
{
     public interface IRule
    {
        bool ShouldLive(bool isAlive, int liveNeighbors);
    }
}
