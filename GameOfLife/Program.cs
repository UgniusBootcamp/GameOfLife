using GameOfLife.Interfaces;
using GameOfLife.Services;

public class Program
{
    public static void Main(string[] args)
    {
        int length;
        int height;

        int generations = 0;

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

        IGameService gameService = new GameService(length, height);

        gameService.Run(generations);
    }
}
