using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Game : IGame
    {
        public IMap Map { get; private set; }

        private readonly IPrintable _mapPrinter;
        private readonly IGameHandler _gameHandler;

        public Game(IMap map, IGameHandler gameHandler)
        {
            Map = map;
            _gameHandler = gameHandler;
            _mapPrinter = new MapPrinter(map);
        }   

        public void Run(int iterations, int delay = 1000)
        {
            for (int i = 0; i <= iterations; i++)
            {
                Console.Clear();
                Console.WriteLine($"Generation: {i}");
                _mapPrinter.Print();

                Map = _gameHandler.CalculateNextGeneration(Map);

                Thread.Sleep(delay);
            }
        }
    }
}
