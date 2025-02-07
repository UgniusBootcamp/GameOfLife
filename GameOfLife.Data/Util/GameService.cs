using GameOfLife.Data.Constants;
using GameOfLife.Data.Enums;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameService(IGameCreator gameCreator, IGameLoader gameLoader, IGamePrinter gamePrinter, IGameSaver gameSaver, IOutputHandler outputHandler) 
        : GameController(gameCreator, gameLoader, gamePrinter, gameSaver, outputHandler)
    {
        private IEnumerable<IGame> games = [];
        private bool _isRunning = true;
        private bool _isPaused;
        private Barrier? _barrier;
        private string[] messages = [GameConstants.GameRunningMessage];

        public override void Execute(GameAction action)
        {
            _outputHandler.Clear();

            switch (action)
            {
                case GameAction.Start:
                    games = _gameCreator.CreateGames();
                    break;
                case GameAction.Load:
                    Load();
                    break;
            }

            _barrier = new Barrier(games.Count(), (b) =>
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

        private void Load()
        {
            games = _gameLoader.LoadGames();
            if (games.Count() == 0)
            {
                _outputHandler.Clear();
                _outputHandler.Output("No Games found");
                _outputHandler.Output("Press 'N' to Start New Game");

                ListenForKeyPress();
            }
        }

        protected override void Print()
        {
            lock(_gamePrinter)
            {
                _gamePrinter.PrintGames(messages, games.ToList());
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
                        case ConsoleKey.N:
                            Execute(GameAction.Start);
                            break;
                    }
                }
            }
        }
    }
}
