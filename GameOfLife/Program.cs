using GameOfLife.Data.Constants;
using GameOfLife.Data.Entities;
using GameOfLife.Data.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        int length;
        int height;

        int generations;

        Console.WriteLine(GameConstants.LenghtInputMessage);
        if (!int.TryParse(Console.ReadLine(), out length))
            length = GameConstants.DefaultMapLength;

        Console.WriteLine(GameConstants.HeightInputMessage);
        if (!int.TryParse(Console.ReadLine(), out height))
            height = GameConstants.DefaultMapHeight;

        Console.WriteLine(GameConstants.GenerationsInputMessage);
        if (!int.TryParse(Console.ReadLine(), out generations))
            generations = GameConstants.DefaultGenerations;

        length = length < 0 ? GameConstants.DefaultMapLength : length;
        height = height < 0 ? GameConstants.DefaultMapHeight : height;
        generations = generations < 0 ? GameConstants.DefaultGenerations : generations;

        Map map = new(height, length);

        IRule defaultGameRule = new DefaultRule();

        IGameHandler gameHandler = new GameHandler(defaultGameRule);

        IGame game = new Game(map, gameHandler, (g => new GamePrinter(g)));

        game.Run(generations);
    }
}
