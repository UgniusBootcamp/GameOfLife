using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities;
using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Entities.Rules;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameCreationService(IInputHandler inputHandler) : IGameReceiver
    {
        private readonly IInputHandler _inputHandler = inputHandler;

        public IGame GetGame()
        {
            int length = _inputHandler.GetInt(GameConstants.LenghtInputMessage);
            int height = _inputHandler.GetInt(GameConstants.HeightInputMessage);
            Console.Clear();

            IMap map = new Map(height, length);
            IGameHandler gameHandler = new GameHandler(new DefaultRule());
            return new Game(map, gameHandler);

        }
    }
}
