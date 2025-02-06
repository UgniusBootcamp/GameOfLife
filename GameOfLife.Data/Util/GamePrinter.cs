using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class GamePrinter : IGamePrinter
    {

        public void PrintGames(string[] messages, IReadOnlyList<IGame> games)
        {
            Console.Clear();

            int xOffset = 0;

            foreach (var game in games)
            {
                PrintGame(game, xOffset, 0);
                xOffset += game.Map.Length + 10;
            }

            Console.SetCursorPosition(0, games[0].Map.Height + 4);
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
