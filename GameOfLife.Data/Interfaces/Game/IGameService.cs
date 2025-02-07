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

        public abstract void Execute(GameAction action);
        protected abstract void Print();
        protected abstract void Pause();
        protected abstract void Resume();
        protected abstract void Exit();
        protected abstract void Save();
        protected abstract void ListenForKeyPress();
    }
}
