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
        private const int defaultGamesCount = GameConstants.DefaultGameRunCount;

        /// <summary>
        /// Method to create games
        /// </summary>
        /// <returns>new games</returns>
        public IEnumerable<IGame> CreateGames()
        {
            int length = _inputHandler.GetInt(GameConstants.LenghtInputMessage);
            if (length <= 0) length = GameConstants.DefaultMapSize;

            int height = _inputHandler.GetInt(GameConstants.HeightInputMessage);
            if (height <= 0) height = GameConstants.DefaultMapSize;

            Console.Clear();

            List<IGame> games = new List<IGame>();

            for(int i = 0; i < defaultGamesCount; i++)
            {
                games.Add(new Game(new Map(height, length), _gameLogic));
            }

            return games;

        }
    }
}
