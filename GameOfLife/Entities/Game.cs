using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Game : IGame
    {
        public int Generation { get; private set; } = 0;
        public IMap Map { get; private set; }

        private readonly Lazy<IPrintable> _gamePrinter;
        private readonly IGameHandler _gameHandler;

        public Game(IMap map, IGameHandler gameHandler, Func<Game, IPrintable> printer)
        {
            Map = map;
            _gamePrinter = new Lazy<IPrintable>(() => printer(this));
            _gameHandler = gameHandler;
        }   

        public void Run(int iterations, int delay = 1000)
        {
            _gamePrinter.Value.Print();

            for (int i = 0; i <= iterations; i++)
            {
                Map = _gameHandler.CalculateNextGeneration(Map);
                Generation++;

                _gamePrinter.Value.Print();

                Thread.Sleep(delay);
            }
        }
    }
}
