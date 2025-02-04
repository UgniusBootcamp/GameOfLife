namespace GameOfLife.Interfaces
{
    public interface IGame
    {
        int Generation { get; }
        IMap Map { get; }
        void Run(int iterations, int delay = 1000);
    }
}
