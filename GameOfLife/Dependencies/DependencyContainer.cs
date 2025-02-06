using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Services;
using GameOfLife.UI;


namespace GameOfLife.Dependencies
{
    public class DependencyContainer
    {
        public static IInputHandler InputHandler => new UserInputHandler();
        public static IGameControllerReceiver GameLoaderService => new GameLoaderService();
        public static IGameControllerReceiver GameCreationService => new GameCreationService(InputHandler);
    }
}
