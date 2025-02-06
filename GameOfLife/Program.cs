using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Services;
using GameOfLife.Dependencies;
using GameOfLife.UI;

public class Program
{
    public static void Main(string[] args)
    {

        GameService newGameService = new GameService(DependencyContainer.GameCreationService);
        GameService oldGameService = new GameService(DependencyContainer.GameLoaderService);


        List<IMenuItem> items = new List<IMenuItem>()
        {
            new MenuItem( "Start Game", newGameService.Execute),
            new MenuItem( "Load Game", oldGameService.Execute),
            new MenuItem( "Exit", () => Environment.Exit(0))
        };

        Menu mainMenu = new ConsoleMenu(items);


        mainMenu.Show();
    }
}
