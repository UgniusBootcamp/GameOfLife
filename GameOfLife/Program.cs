using GameOfLife.Data.Constants;
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
            new MenuItem( GameConstants.StartGame, () => DependencyContainer.GameService.Execute(GameAction.Start)),
            new MenuItem( GameConstants.LoadGame, () => DependencyContainer.GameService.Execute(GameAction.Load)),
            new MenuItem( GameConstants.Exit, () => Environment.Exit(0))
        };

        var mainMenu = new ConsoleMenu(items);

        mainMenu.Show();
    }
}
