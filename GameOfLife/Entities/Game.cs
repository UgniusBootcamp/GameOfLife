using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Game : IGame
    {
        public int Generation { get; private set; } = 0;
        public IMap Map { get; private set; }

        private readonly IPrintable _gamePrinter;
        private readonly IGameHandler _gameHandler;

        /// <summary>
        /// Constructor for Game
        /// </summary>
        /// <param name="map">map</param>
        /// <param name="gameHandler">handler for game logic</param>
        /// <param name="printer">printer for console print logic</param>
        public Game(IMap map, IGameHandler gameHandler, Func<Game, IPrintable> printer)
        {
            Map = map;
            _gamePrinter = printer(this);
            _gameHandler = gameHandler;
        }

        /// <summary>
        /// Run the game for a number of iterations
        /// </summary>
        /// <param name="iterations">number of iteration a game should run</param>
        /// <param name="delay">delay for each iteration</param>
        public void Run(int iterations, int delay = 1000)
        {
            _gamePrinter.Print();

            for (int i = 0; i <= iterations; i++)
            {
                Map = _gameHandler.CalculateNextGeneration(Map);

                Generation++;

                _gamePrinter.Print();

                Thread.Sleep(delay);
            }
        }
    }
}
