using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Entities.Game
{
    public class GameController
    {
        private bool _isRunning;
        private bool _isPaused;
        private readonly object _lock = new();
        private IGame _game;
        private IPrintable _printer;

        public GameController(IGame game, IPrintable printer)
        {
            _game = game;
            _printer = printer;
            _isRunning = true;
            _isPaused = false;
        }

        public void Run()
        {
            while (_isRunning)
            {
                lock (_lock)
                {
                    while (_isPaused)
                    {
                        Monitor.Wait(_lock);
                    }

                    _game.Iterate();
                    _printer.Print();
                }

                Thread.Sleep(GameConstants.DefaultDelay);
            }
        }

        public void Pause()
        {
            lock (_lock)
            {
                _isPaused = true;
            }
        }

        public void Resume()
        {
            lock (_lock)
            {
                _isPaused = false;
                Monitor.Pulse(_lock);
            }
        }

        public void Exit()
        {
            lock (_lock)
            {
                _isRunning = false;
                Monitor.Pulse(_lock);
            }
        }
    }
}
