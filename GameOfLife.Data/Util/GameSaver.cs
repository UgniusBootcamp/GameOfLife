
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

        public void SaveGames(List<IGame> games) 
        {
            Console.Clear();
            var fileName = _inputHandler.GetString("Enter file name: ") ?? GameConstants.DefaultGameFileName;
            _fileService.SaveGame(fileName, games);
            Console.Clear();
        }
    }
}
