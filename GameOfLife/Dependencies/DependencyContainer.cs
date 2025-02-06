using GameOfLife.Data.Entities.Games;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;
using GameOfLife.Data.Util;
using GameOfLife.UI;


namespace GameOfLife.Dependencies
{
    public class DependencyContainer
    {
        public static IInputHandler InputHandler => new UserInputHandler();
        public static IGameReceiver GameLoaderService => new GameLoaderService();
        public static IGameReceiver GameCreationService => new GameCreationService(InputHandler);
        public static IFileService JsonFileService => new JsonFileService();
        public static IGameSaver GameSaver => new GameSaver(InputHandler, JsonFileService);
        public static GameController GameCreator => new GameService(GameCreationService, GamePrinter, GameSaver);
        public static GameController GameLoader => new GameService(GameLoaderService, GamePrinter, GameSaver);
        public static IGamePrinter GamePrinter => new GamePrinter();
    }
}
