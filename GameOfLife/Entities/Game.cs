using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Game : IGame
    {
        public int Generation { get; private set; } = 0;
        public int Population { get; private set; } = 0;
        public IMap Map { get; private set; }

        private IPrintable _gameServicePrinter;

        public Game(IMap map)
        {
            Map = map;
            _gameServicePrinter = new GamePrinter(this);
        }

        private int CountAliveNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= Map.Height || j >= Map.Length)
                    {
                        continue;
                    }
                    if (Map.GetCell(i, j).IsAlive)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private void NextGeneration()
        {
            int length = Map.Length;
            int height = Map.Height;
            int aliveCells = 0;

            var nextMap = new Map(height, length);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    var cell = Map.GetCell(i, j);
                    var aliveNeighbours = CountAliveNeighbours(i, j);

                    var nextState = cell.NextState(aliveNeighbours);

                    if (nextState) aliveCells++;

                    nextMap.SetCell(new Cell(i, j, nextState));
                }
            }

            Map = nextMap;
            Population = aliveCells;
            Generation++;
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
