using GameOfLife.Constants;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class GamePrinter(IGame game) : IPrintable
    {
        private readonly IGame _game = game;

        /// <summary>
        /// Print the game to the console
        /// </summary>
        public void Print()
        { 
            var map = _game.Map;

            Console.Clear();
            Console.WriteLine(GameConstants.GenerationMessage, _game.Generation);
            Console.WriteLine(GameConstants.PopulationMessage, map.Population);
            Console.WriteLine("+" + new String('-', map.Length) + "+");

            for (int i = 0; i < map.Height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < map.Length; j++)
                {
                    Console.Write(map.GetCell(i, j).IsAlive ? GameConstants.Alive : GameConstants.Dead);
                }
                Console.WriteLine("|");
            }

            Console.WriteLine("+" + new String('-', map.Length) + "+");
        }
    }
}
