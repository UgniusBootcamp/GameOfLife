using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Entities.Game
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

            Console.CursorVisible = false;

            ClearGrid(0, 2, map.Length + 5, map.Height + 4);

            Console.SetCursorPosition(0, 2);
            Console.WriteLine(GameConstants.GenerationMessage, _game.Generation);
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

        private void ClearGrid(int x, int y, int length, int height)
        {
            for (int i = 0; i < height; i++)
            {
                ClearLine(x, y + i, length);
            }
        }

        private void ClearLine(int x, int y, int length)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(x, y);
        }
    }
}
