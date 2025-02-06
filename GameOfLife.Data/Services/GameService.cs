using GameOfLife.Data.Entities.Game;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Services
{
    public class GameService : IGameService
    {
        private readonly IGameControllerReceiver _gameControllerReceiver;
        private GameController? _gameControllers;
        private bool _isRunning = true;

        public GameService(IGameControllerReceiver gameControllerReceiver)
        {
            _gameControllerReceiver = gameControllerReceiver;
        }

        public void Execute()
        {
            var gameController = _gameControllerReceiver.GetGameController();

            _gameControllers = gameController;


            Console.WriteLine("Press 'P' to pause, 'R' to resume, 'Q' to exit");

            var thread = new Thread(_gameControllers.Run);
            thread.Start();

            ListenForKeyPress();
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
                            _gameControllers!.Pause();
                            break;
                        case ConsoleKey.R:
                            _gameControllers!.Resume();
                            break;
                        case ConsoleKey.Q:
                            _gameControllers!.Exit();
                            Environment.Exit(0);
                            _isRunning = false;
                            return;
                    }
                }
            }
        }
    }
}
