using System.Security.Cryptography.X509Certificates;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities;
using GameOfLife.Data.Entities.Menu;
using GameOfLife.Data.Entities.MenuActions;

public class Program
{
    public static void Main(string[] args)
    {
        var startGame = new StartGame("Start New Game");
        var saveGame = new SaveGame("Save Game");
        var exitGame = new ExitGame("Exit Game");

        var startMenu = new StartMenu([startGame, exitGame]);
        var gameMenu = new GameMenu([saveGame, exitGame]);

        MenuManager menuManager = new MenuManager([startMenu, gameMenu]);

        menuManager.ShowMenu();
    }
}
