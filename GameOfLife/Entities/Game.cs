using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Game : IGame
    {
        private int generation = 0;
        private int population = 0;
        private IMap _map;
        private IPrintable _gameServicePrinter;

        public int Generation => generation;
        public int Population => population;
        public IMap Map => _map;

        public Game(IMap map)
        {
            _map = map;
            _gameServicePrinter = new GamePrinter(this);
        }

        private int CountAliveNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= _map.Height || j >= _map.Length)
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

            var nextMap = new Map(height, length);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
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

        public void Run(int iterations, int delay = 1000)
        {
            for (int i = 0; i <= iterations; i++)
            {
                _gameServicePrinter.Print();
                NextGeneration();
                Thread.Sleep(delay);
            }
        }
    }
}
