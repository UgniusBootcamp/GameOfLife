using System.Security.Cryptography.X509Certificates;
using GameOfLife.Entities;
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
        length = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the height of the map: ");
        height = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the number of generations: ");
        generations = Convert.ToInt32(Console.ReadLine());

        length = length < 0 ? length : 10;
        height = height < 0 ? height : 10;
        generations = generations < 0 ? generations : 100;

        IGameService gameService = new GameService(length, height);

        gameService.Run(generations);
    }
}
