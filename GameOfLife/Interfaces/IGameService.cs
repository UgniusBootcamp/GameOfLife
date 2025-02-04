using System;
namespace GameOfLife.Interfaces
{
    public interface IGameService
    {
        void Run(int iterations, int delay = 1000);
    }
}
