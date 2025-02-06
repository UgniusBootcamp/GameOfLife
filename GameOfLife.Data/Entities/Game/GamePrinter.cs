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
            
            ClearLine(xOffset, yOffset);
            ClearLine(xOffset, yOffset+1);

            foreach (var game in games)
            {
                PrintGame(game, xOffset, yOffset);
                xOffset += game.Map.Length + 10;
            }
        }

        private void ClearLine(int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.Write(new String(' ', Console.WindowWidth));
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
            Console.Write(GameConstants.MapCorner + new String(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
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
            Console.Write(GameConstants.MapCorner + new String(GameConstants.MapHorizontalBorder, map.Length) + GameConstants.MapCorner);
        }
    }
}
