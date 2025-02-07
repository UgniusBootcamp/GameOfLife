using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameSaver(IInputHandler inputHandler, IFileService fileService) : IGameSaver
    {
        private readonly IInputHandler _inputHandler = inputHandler;
        private readonly IFileService _fileService = fileService;

        /// <summary>
        /// Method to save games 
        /// </summary>
        /// <param name="games">games to save</param>
        public void SaveGames(IEnumerable<IGame> games) 
        {
            Console.Clear();
            var fileName = _inputHandler.GetString(GameConstants.FileNameEnterMessage);

            if (String.IsNullOrEmpty(fileName)) fileName = GameConstants.DefaultGameSaveName;

            var gamesDto = games.Select(g => g.GetGameDto());

            _fileService.SaveGame(fileName, gamesDto);
            Console.Clear();
        }
    }
}
