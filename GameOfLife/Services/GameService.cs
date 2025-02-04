using GameOfLife.Entities;
using GameOfLife.Interfaces;

namespace GameOfLife.Services
{
    public class GameService : IGameService, IPrintable
    {
        private int generation = 0;
        private int population = 0;
        private Map _map;

        public GameService(int mapLength, int mapHeight)
        {
            _map = new Map(mapLength, mapHeight);
        }

        private int CountAliveNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= _map.Length || j >= _map.Height )
                    {
                        continue;
                    }
                    if (_map.GetCell(i, j).IsAlive)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void NextGeneration()
        {
            int length = _map.Length;
            int height = _map.Height;
            int aliveCells = 0;

            var nextMap = new Map(length, height);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var cell = _map.GetCell(i, j);
                    var aliveNeighbours = CountAliveNeighbours(i, j);

                    var nextState = cell.NextState(aliveNeighbours);

                    if (nextState) aliveCells++;

                    nextMap.SetCell(new Cell(i, j, nextState));
                }
            }

            _map = nextMap;
            population = aliveCells;
            generation++;
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine($"Generation: {generation}");
            Console.WriteLine($"Population: {population}");
            _map.Print();
        }

        public void Run(int iterations, int delay = 1000)
        {
            for (int i = 0; i <= iterations; i++)
            {
                Print();
                NextGeneration();
                Thread.Sleep(delay);
            }
        }
    }
}
