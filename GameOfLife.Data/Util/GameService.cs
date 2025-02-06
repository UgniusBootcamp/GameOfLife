using System.Threading;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameService(IGameReceiver gameReceiver, IGamePrinter gamePrinter, IGameSaver gameSaver) : GameController(gameReceiver, gamePrinter, gameSaver)
    {
        private readonly List<IGame> games = [];
        private bool _isRunning = true;
        private bool _isPaused;
        private Barrier? _barrier;
        private string[] messages = [GameConstants.GameRunningMessage];

        public override void Execute()
        {
            var game = _gameReceiver.GetGame();
            var game1 = _gameReceiver.GetGame();

            games.Add(game);
            games.Add(game1);

            _barrier = new Barrier(games.Count, (b) =>
            {
                Print();
            });

            var threads = games.Select(g => new Thread(() => Run(g))).ToList();
            threads.ForEach(t => t.Start());

            ListenForKeyPress();

            threads.ForEach(t => t.Join());
        }

        protected void Run(IGame game)
        {
            while (_isRunning)
            {
                if (_isPaused) continue;

                game.Iterate();

                _barrier!.SignalAndWait();

                Thread.Sleep(GameConstants.DefaultDelay);
            }
        }

        protected override void Print()
        {
            lock(_gamePrinter)
            {
                _gamePrinter.PrintGames(messages, games);
            }
        }

        protected override void Pause()
        {
            _isPaused = true;
            messages = [GameConstants.GamePausedMessage, "Game is Paused"];
            Print();
        }

        protected override void Resume()
        {
            _isPaused = false;
            messages = [GameConstants.GameRunningMessage];
            Print();
        }

        protected override void Exit()
        {
            _isRunning = false;
        }

        protected override void Save()
        {
            if (_isRunning && _isPaused)
            {
                _gameSaver.SaveGames(games);
                Print();
            }
        }

        protected override void ListenForKeyPress()
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
                        case ConsoleKey.S:
                            Save();
                            break;
                    }
                }
            }
        }
    }
}
