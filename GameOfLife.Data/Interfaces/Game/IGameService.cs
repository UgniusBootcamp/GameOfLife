using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Interfaces.Game
{
    public abstract class GameController(IGameReceiver gameReceiver, IGamePrinter gamePrinter, IGameSaver gameSaver)
    {
        protected readonly IGamePrinter _gamePrinter = gamePrinter;
        protected readonly IGameReceiver _gameReceiver = gameReceiver;
        protected readonly IGameSaver _gameSaver = gameSaver;

        public abstract void Execute();
        protected abstract void Print();
        protected abstract void Pause();
        protected abstract void Resume();
        protected abstract void Exit();
        protected abstract void Save();
        protected abstract void ListenForKeyPress();
    }
}
