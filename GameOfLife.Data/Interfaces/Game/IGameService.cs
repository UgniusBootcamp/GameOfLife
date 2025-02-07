using GameOfLife.Data.Enums;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Interfaces.Game
{
    public abstract class GameController(IGameCreator gameCreator, IGameLoader gameLoader, IGamePrinter gamePrinter, IGameSaver gameSaver,IOutputHandler outputHandler)
    {
        protected readonly IGamePrinter _gamePrinter = gamePrinter;
        protected readonly IGameCreator _gameCreator = gameCreator;
        protected readonly IGameLoader _gameLoader = gameLoader;
        protected readonly IGameSaver _gameSaver = gameSaver;
        protected readonly IOutputHandler _outputHandler = outputHandler;

        /// <summary>
        /// Method for game execution
        /// </summary>
        /// <param name="action">action how to get game</param>
        public abstract void Execute(GameAction action);

        /// <summary>
        /// Print games
        /// </summary>
        protected abstract void Print();

        /// <summary>
        /// Pause games
        /// </summary>
        protected abstract void Pause();

        /// <summary>
        /// Resume games
        /// </summary>
        protected abstract void Resume();

        /// <summary>
        /// Exit games
        /// </summary>
        protected abstract void Exit();

        /// <summary>
        /// Save games
        /// </summary>
        protected abstract void Save();

        /// <summary>
        /// Listen for key presses to perform previous actions
        /// </summary>
        protected abstract void ListenForKeyPress();
    }
}
