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
        private bool _isRunning;
        private bool _isPaused;
        private int firstGame;
        private int gamesToShow = GameConstants.GamesToShow;
        private Barrier? _barrier;
        private string message = string.Empty;

        /// <summary>
        /// Execution of games
        /// </summary>
        /// <param name="action">action of how games are created</param>
        public override void Execute(GameAction action)
        {
            firstGame = 0;
            _isRunning = false;
            _isPaused = false;
            message = GameConstants.GameRunningMessage;

            _outputHandler.Clear();

            switch (action)
            {
                case GameAction.Start:
                    games = _gameCreator.CreateGames();
                    break;
                case GameAction.Load:
                    games = _gameLoader.LoadGames();
                    _outputHandler.Clear();
                    break;
            }

            if (!games.Any())
            {
                _outputHandler.Output(GameConstants.NoGameFoundMessage);
                games = _gameCreator.CreateGames();
            }

            gamesToShow = Math.Min(games.Count(), gamesToShow);

            _barrier = new Barrier(games.Count(), (b) =>
            {
                Print();
            });

            _isRunning = true;

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
        /// Method to print games
        /// </summary>
        protected override void Print()
        {
            lock(_gamePrinter)
            {
                var header = String.Format(GameConstants.Header, games.First().Generation, AliveCells, games.Count());
                _gamePrinter.PrintGames(header, message, games.Skip(firstGame).Take(gamesToShow));
            }
        }

        /// <summary>
        /// Method to pause games
        /// </summary>
        protected override void Pause()
        {
            _isPaused = true;
            message = String.Format("{0}. {1}", GameConstants.GamePausedMessage, GameConstants.GameIsPause);
            Print();
        }

        /// <summary>
        /// method to resume games
        /// </summary>
        protected override void Resume()
        {
            _isPaused = false;
            message = GameConstants.GameRunningMessage;
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

        /// <summary>
        /// Method to move right to displayed list
        /// </summary>
        protected void MoveRight()
        {
            if (firstGame + gamesToShow == games.Count()) return;

            firstGame++;
            Print();
        }

        /// <summary>
        /// Method to move left to displayed list
        /// </summary>
        protected void MoveLeft()
        {
            if(firstGame == 0) return;

            firstGame--;
            Print();
        }

        /// <summary>
        /// Variable to see how many cells are alive across all games
        /// </summary>
        protected int AliveCells 
        {
            get
            {
                return games.Sum(g => g.Map.Population);
            }
        }

        private void StopAndRestart(GameAction action)
        {
            _isRunning = false;
            Thread.Sleep(100);
            Execute(action);
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
                            if (!_isPaused) break;
                            StopAndRestart(GameAction.Start);
                            break;
                        case ConsoleKey.L:
                            if (!_isPaused) break;
                            StopAndRestart(GameAction.Load);
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
