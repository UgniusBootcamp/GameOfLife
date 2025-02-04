using System;
namespace GameOfLife.Interfaces
{
    public interface IGame
    {
        void Run(int iterations, int delay = 1000);
        IMap Map { get; }
    }
}
