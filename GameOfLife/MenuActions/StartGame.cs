using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.MenuActions
{
    public class StartGame(string name) : MenuAction(name)
    {
        public override void Execute()
        {
            Console.WriteLine(GameConstants.LenghtInputMessage);
            if (!int.TryParse(Console.ReadLine(), out int length))
                length = GameConstants.DefaultMapLength;

            Console.WriteLine(GameConstants.HeightInputMessage);
            if (!int.TryParse(Console.ReadLine(), out int height))
                height = GameConstants.DefaultMapHeight;

            Console.WriteLine(GameConstants.GenerationsInputMessage);
            if (!int.TryParse(Console.ReadLine(), out int generations))
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
}
