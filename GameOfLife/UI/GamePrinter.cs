using System.ComponentModel.DataAnnotations;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.UI
{
    public class GamePrinter : IGamePrinter
    {

        /// <summary>
        /// Method for printing Games and messages to user
        /// </summary>
        /// <param name="messages">message below games</param>
        /// <param name="games">games to print</param>
        public void PrintGames(string[] messages, IEnumerable<IGame> games)
        {
            if(games.Count() == 0) return;

            Console.Clear();

            int xOffset = 0;

            foreach (var game in games)
            {
                PrintGame(game, xOffset, 0);
                xOffset += game.Map.Length + GameConstants.NextMapLengthOffset;
            }

            var maxHeight = games.MaxBy(g => g.Map.Height)!.Map.Height;

            Console.SetCursorPosition(0, maxHeight + GameConstants.MessageOffset);
            Console.ForegroundColor = ConsoleColor.Green;
            messages.ToList().ForEach(message => Console.WriteLine(message));
            Console.ResetColor();
        }

        /// <summary>
        /// Print the game to the console
        /// </summary>
        private void PrintGame(IGame game, int xOffset, int yOffset)
        {
            var map = game.Map;

            Console.CursorVisible = false;

            Console.SetCursorPosition(xOffset, yOffset);

            Console.Write(GameConstants.GenerationMessage, game.Generation);
            Console.SetCursorPosition(xOffset, ++yOffset);
            Console.Write(GameConstants.PopulationMessage, map.Population);
            Console.SetCursorPosition(xOffset, ++yOffset);
            Console.Write(GameConstants.MapCorner + new string(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
            for (int i = 0; i < map.Height; i++)
            {
                Console.SetCursorPosition(xOffset, ++yOffset);
                Console.Write(GameConstants.MapVerticalBorder);
                for (int j = 0; j < map.Length; j++)
                {
                    Console.Write(map.GetCell(i, j).IsAlive ? GameConstants.Alive : GameConstants.Dead);
                }
                Console.Write(GameConstants.MapVerticalBorder);
            }
            Console.SetCursorPosition(xOffset, ++yOffset);
            Console.Write(GameConstants.MapCorner + new string(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
        }
    }
}
