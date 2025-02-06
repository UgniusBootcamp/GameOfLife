using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities;
using GameOfLife.Data.Entities.Game;
using GameOfLife.Data.Entities.Rules;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Services
{
    public class GameCreationService(IInputHandler inputHandler) : IGameControllerReceiver
    {
        private readonly IInputHandler _inputHandler = inputHandler;

        public GameController GetGameController()
        {
            int length = _inputHandler.GetInt(GameConstants.LenghtInputMessage);
            int height = _inputHandler.GetInt(GameConstants.HeightInputMessage);
            Console.Clear();

            IMap map = new Map(height, length);
            IGameHandler gameHandler = new GameHandler(new DefaultRule());
            IGame game = new Game(map, gameHandler);
            IPrintable printer = new GamePrinter(game);
            return new GameController(game, printer);
        }
    }
}
