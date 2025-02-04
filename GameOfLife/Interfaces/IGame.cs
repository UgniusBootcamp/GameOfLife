using System;
namespace GameOfLife.Interfaces
{
    public interface IGame
    {
        void Run(int iterations, int delay = 1000);
        int Population { get; }
        int Generation { get; }
        IMap Map { get; }
    }
}
