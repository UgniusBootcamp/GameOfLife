using GameOfLife.Entities;
using GameOfLife.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        int length;
        int height;

        int generations;

        Console.WriteLine("Enter the length of the map: ");
        if (!int.TryParse(Console.ReadLine(), out length))
            length = 10;

        Console.WriteLine("Enter the height of the map: ");
        if (!int.TryParse(Console.ReadLine(), out height))
            height = 10;

        Console.WriteLine("Enter the number of generations: ");
        if (!int.TryParse(Console.ReadLine(), out generations))
            generations = 100;

        length = length < 0 ? 10 : length;
        height = height < 0 ? 10 : height;
        generations = generations < 0 ? 100 : generations;

        Map map = new(height, length);

        IRule defaultGameRule = new DefaultRule();

        IGameHandler gameHandler = new GameHandler(defaultGameRule);

        IGame game = new Game(map, gameHandler, (g => new GamePrinter(g)));

        game.Run(generations);
    }
}
