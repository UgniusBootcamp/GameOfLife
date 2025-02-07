using GameOfLife.Data.Entities;
using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GameLoaderService : IGameLoader
    {
        private readonly IFileService _fileService;
        private readonly IGameLogic _gameLogic;
        private readonly IOptionSelector _optionSelector;

        public GameLoaderService(IGameLogic gameLogic, IFileService fileService, IOptionSelector otionSelector)
        {
            _gameLogic = gameLogic;
            _fileService = fileService;
            _optionSelector = otionSelector;
        }

        public IEnumerable<IGame> LoadGames()
        {
            var fileName = GetFile();

            var gameDtos = _fileService.ReadGame(fileName);

            var games = gameDtos.Select(g => new Game(new Map(g.Map), _gameLogic));

            return games;
        }

        private string GetFile()
        {
            var files = FileSystem.Instance.GetDirFiles();
            var selected = _optionSelector.Select(files);

            return files[selected];
        }
    }
}
