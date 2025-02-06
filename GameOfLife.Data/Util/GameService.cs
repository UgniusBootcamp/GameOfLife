using System.Threading;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameService(IGameReceiver gameReceiver, IGamePrinter gamePrinter) : GameController(gameReceiver, gamePrinter)
    {
        private List<IGame> games = new List<IGame>();
        private bool _isRunning = true;
        private bool _isPaused;
        private Barrier _barrier;

        public override void Execute()
        {
            var game = _gameReceiver.GetGame();
            var game1 = _gameReceiver.GetGame();

            games.Add(game);
            games.Add(game1);

            Console.WriteLine("Press 'P' to pause, 'R' to resume, 'Q' to exit");

            _barrier = new Barrier(games.Count, (b) =>
            {
                _gamePrinter.PrintGames(games);
            });

            var threads = games.Select(g => new Thread(() => Run(g))).ToList();
            threads.ForEach(t => t.Start());

            ListenForKeyPress();

            threads.ForEach(t => t.Join());
        }

        private void Run(IGame game)
        {
            while (_isRunning)
            {
                if (_isPaused) continue;

                game.Iterate();

                _barrier.SignalAndWait();

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
