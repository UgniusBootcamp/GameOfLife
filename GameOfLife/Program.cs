using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Enums;
using GameOfLife.Data.Interfaces;
using GameOfLife.Dependencies;
using GameOfLife.UI;

public class Program
{
    public static void Main(string[] args)
    {

        List<IMenuItem> items = new List<IMenuItem>()
        {
            new MenuItem( "Start Game", () => DependencyContainer.GameService.Execute(GameAction.Start)),
            new MenuItem( "Load Game", () => DependencyContainer.GameService.Execute(GameAction.Load)),
            new MenuItem( "Exit", () => Environment.Exit(0))
        };

        var mainMenu = new ConsoleMenu(items);

        mainMenu.Show();
    }
}
