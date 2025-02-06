using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities.Game;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Services
{
    public class GameService(IGameReceiver gameReceiver, IGamePrinter gamePrinter) : GameController(gameReceiver, gamePrinter)
    {
        private List<IGame> games = new List<IGame>();
        private bool _isRunning = true;
        private bool _isPaused;

        public override void Execute()
        {
            var game = _gameReceiver.GetGame();
            var game1 = _gameReceiver.GetGame();

            games.Add(game);
            games.Add(game1);

            Console.WriteLine("Press 'P' to pause, 'R' to resume, 'Q' to exit");

            var gameTasks = games.Select(g => Task.Run(() => Run(g))).ToArray();
            var keyPressTask = Task.Run(() => ListenForKeyPress());

            Task.WhenAll(gameTasks).ContinueWith(_ => _gamePrinter.PrintGames(games)).Wait();

        }

        private void Run(IGame game)
        {
            while (_isRunning)
            {
                if (_isPaused) continue;

                game.Iterate();

                Thread.Sleep(1000);
            }
        }

        private void Pause()
        {
            _isPaused = true;
        }

        public void Resume()
        {
            _isPaused = false;
        }

        public void Exit()
        {
            _isRunning = false;
        }

        private void ListenForKeyPress()
        {
            while (_isRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.P:
                            Pause();
                            break;
                        case ConsoleKey.R:
                            Resume();
                            break;
                        case ConsoleKey.Q:
                            Exit();
                            return;
                    }
                }
            }
        }
    }
}
