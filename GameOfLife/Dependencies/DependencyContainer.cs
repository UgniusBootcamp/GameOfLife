using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Entities.Rules;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;
using GameOfLife.Data.Util;
using GameOfLife.UI;


namespace GameOfLife.Dependencies
{
    public class DependencyContainer
    {
        static IInputHandler ConsoleInput => new ConsoleInput();
        static IOutputHandler ConsoleOutput => new ConsoleOutput();
        static IOptionSelector OptionSelector => new OptionSelector(ConsoleOutput, ConsoleInput);
        static readonly IRule DefaultRule = new DefaultRule();
        static readonly IGameLogic GameLogic = new GameLogic(DefaultRule);
        static IGameCreator GameCreationService => new GameCreationService(ConsoleInput, GameLogic);
        static IGameLoader GameLoadingService => new GameLoaderService(GameLogic, JsonFileService, OptionSelector);
        static IFileService JsonFileService => new JsonFileService(ConsoleOutput);
        static IGameSaver GameSaver => new GameSaver(ConsoleInput, JsonFileService);
        public static GameController GameService => new GameService(GameCreationService, GameLoadingService, GamePrinter, GameSaver, ConsoleOutput);
        static IGamePrinter GamePrinter => new GamePrinter();
    }
}
