using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities.Menus;
using GameOfLife.Data.Enums;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Util;
using GameOfLife.Dependencies;
using GameOfLife.UI;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var services = DependencyContainer.ConfigureService();

        List<IMenuItem> items = new List<IMenuItem>()
        {
            new MenuItem( GameConstants.StartGame, () => services.GetRequiredService<GameService>().Execute(GameAction.Start)),
            new MenuItem( GameConstants.LoadGame, () => services.GetRequiredService<GameService>().Execute(GameAction.Load)),
            new MenuItem( GameConstants.Exit, () => Environment.Exit(0))
        };

        var mainMenu = new ConsoleMenu(items);

        mainMenu.Show();
    }
}
