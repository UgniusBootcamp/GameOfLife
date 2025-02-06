using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.UI;
using GameOfLife.Data.Services;
using GameOfLife.Dependencies;
using GameOfLife.UI;

public class Program
{
    public static void Main(string[] args)
    {

        List<IMenuItem> items = new List<IMenuItem>()
        {
            new MenuItem( "Start Game", DependencyContainer.GameCreator.Execute),
            new MenuItem( "Load Game", DependencyContainer.GameLoader.Execute),
            new MenuItem( "Exit", () => Environment.Exit(0))
        };

        Menu mainMenu = new ConsoleMenu(items);


        mainMenu.Show();
    }
}
