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
        private int firstGame = 0;
        private int gamesToShow = 8;
        private Barrier? _barrier;
        private string[] messages = [GameConstants.GameRunningMessage];

        /// <summary>
        /// Execution of games
        /// </summary>
        /// <param name="action">action of how games are created</param>
        public override void Execute(GameAction action)
        {
            _outputHandler.Clear();

            switch (action)
            {
                case GameAction.Start:
                    games = _gameCreator.CreateGames();
                    gamesToShow = games.Count() < gamesToShow ? games.Count() : gamesToShow;
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

        /// <summary>
        /// Running proccess of a single game
        /// </summary>
        /// <param name="game">game</param>
        protected void Run(IGame game)
        {
            while (_isRunning)
            {
                if (_isPaused)
                {
                    Thread.Sleep(10);
                    continue;
                }

                game.Iterate();

                _barrier!.SignalAndWait();

                Thread.Sleep(GameConstants.DefaultDelay);
            }
        }

        /// <summary>
        /// Helper method to load games
        /// </summary>
        private void Load()
        {
            games = _gameLoader.LoadGames();
            if (games.Count() == 0)
            {
                _outputHandler.Clear();
                _outputHandler.Output(GameConstants.NoGameFoundMessage);
                _outputHandler.Output(GameConstants.StartNewGameMessage);

                ListenForKeyPress();
            }
            gamesToShow = games.Count() < gamesToShow ? games.Count() : gamesToShow;
        }

        /// <summary>
        /// Method to print games
        /// </summary>
        protected override void Print()
        {
            lock(_gamePrinter)
            {
                _gamePrinter.PrintGames(messages, games.Skip(firstGame).Take(gamesToShow));
            }
        }

        /// <summary>
        /// Method to pause games
        /// </summary>
        protected override void Pause()
        {
            _isPaused = true;
            messages = [GameConstants.GamePausedMessage, GameConstants.GameIsPause];
            Print();
        }

        /// <summary>
        /// method to resume games
        /// </summary>
        protected override void Resume()
        {
            _isPaused = false;
            messages = [GameConstants.GameRunningMessage];
            Print();
        }

        /// <summary>
        /// method to exit games
        /// </summary>
        protected override void Exit()
        {
            _isRunning = false;
        }

        /// <summary>
        /// method to save games
        /// </summary>
        protected override void Save()
        {
            if (_isRunning && _isPaused)
            {
                _gameSaver.SaveGames(games);
                Print();
            }
        }

        protected void MoveRight()
        {
            if (firstGame + gamesToShow == games.Count()) return;

            firstGame++;
            Print();
        }

        protected void MoveLeft()
        {
            if(firstGame == 0) return;

            firstGame--;
            Print();
        }

        /// <summary>
        /// key listener for user action for methods to perfom
        /// </summary>
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
                        case ConsoleKey.LeftArrow:
                            MoveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            MoveRight();
                            break;
                    }
                }
            }
        }
    }
}
