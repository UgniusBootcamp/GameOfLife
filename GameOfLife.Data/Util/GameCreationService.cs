using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities;
using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameCreationService(IInputHandler inputHandler, IGameLogic gameLogic) : IGameCreator
    {
        private readonly IInputHandler _inputHandler = inputHandler;
        private readonly IGameLogic _gameLogic = gameLogic;

        /// <summary>
        /// Method to create games
        /// </summary>
        /// <returns>new games</returns>
        public IEnumerable<IGame> CreateGames()
        {
            int gameRunCount = _inputHandler.GetInt(String.Format("{0} {1}", GameConstants.HowManyGame, GameConstants.DefaultGameRunCount));
            if (gameRunCount <= 0 || gameRunCount > GameConstants.DefaultGameRunCount) gameRunCount = GameConstants.DefaultGameRunCount;

            int length = _inputHandler.GetInt(String.Format("{0}{1}", GameConstants.LenghtInputMessage, GameConstants.DefaultMapSize));
            if (length <= 0 || length > GameConstants.DefaultMapSize) length = GameConstants.DefaultMapSize;

            int height = _inputHandler.GetInt(String.Format("{0}{1}", GameConstants.HeightInputMessage, GameConstants.DefaultMapSize));
            if (height <= 0 || height > GameConstants.DefaultMapSize) height = GameConstants.DefaultMapSize;

            Console.Clear();

            List<IGame> games = new List<IGame>();

            for(int i = 0; i < gameRunCount; i++)
            {
                games.Add(new Game(i+1, new Map(height, length), _gameLogic));
            }

            return games;

        }
    }
}
