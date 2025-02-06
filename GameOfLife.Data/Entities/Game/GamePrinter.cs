using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Entities.Game
{
    public class GamePrinter : IGamePrinter
    {

        public void PrintGames(IEnumerable<IGame> games)
        {
            int xOffset = 0;
            int yOffset = 2;

            foreach (var game in games)
            {
                PrintGame(game, xOffset, yOffset);
                xOffset += game.Map.Length + 5;
            }
        }

        /// <summary>
        /// Print the game to the console
        /// </summary>
        private void PrintGame(IGame game, int xOffset, int yOffset)
        { 
            var map = game.Map;

            Console.CursorVisible = false;

            Console.SetCursorPosition(xOffset, yOffset);

            Console.WriteLine(GameConstants.GenerationMessage, game.Generation);
            Console.WriteLine(GameConstants.PopulationMessage, map.Population);
            Console.WriteLine(GameConstants.MapCorner + new String(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
            for (int i = 0; i < map.Height; i++)
            {
                Console.Write(GameConstants.MapVerticalBorder);
                for (int j = 0; j < map.Length; j++)
                {
                    Console.Write(map.GetCell(i, j).IsAlive ? GameConstants.Alive : GameConstants.Dead);
                }
                Console.WriteLine(GameConstants.MapVerticalBorder);
            }

            Console.WriteLine(GameConstants.MapCorner + new String(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
        }

        private void ClearLine(int x, int y, int length)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(x, y);
        }
    }
}
