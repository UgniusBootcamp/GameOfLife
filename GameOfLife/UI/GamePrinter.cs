﻿using System.ComponentModel.DataAnnotations;
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
        public void PrintGames(string header, string menu, IEnumerable<IGame> games)
        {
            if (games.Count() == 0) return;


            int xOffset = 0;
            int yOffset = 0;


            Console.SetCursorPosition(xOffset, yOffset);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine(menu);
            Console.ResetColor();

            Console.SetCursorPosition(xOffset, yOffset);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine(header);

            int maxHeight = games.Max(g => g.Map.Height);
            int maxLength = games.Max(g => g.Map.Length);

            if (maxHeight + GameConstants.NextMapHeightOffset + yOffset >= Console.WindowHeight ||
                maxLength + GameConstants.NextMapLengthOffset + xOffset >= Console.WindowWidth)
            {
                Console.WriteLine(GameConstants.ScreenToSmall);
                return;
            }

            foreach (var game in games)
            {
                PrintGame(game, xOffset, yOffset);
                xOffset += game.Map.Length + GameConstants.NextMapLengthOffset;

                if (xOffset + maxLength > Console.WindowWidth)
                {
                    xOffset = 0;
                    if (yOffset + 2 * (maxHeight + GameConstants.NextMapHeightOffset) > Console.WindowHeight)
                    {
                        break;
                    }
                    else
                    {
                        yOffset += maxHeight + GameConstants.NextMapHeightOffset;
                    }
                }
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
            Console.Write(new string(' ', map.Length));
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.Write($"{GameConstants.Game}{game.Id}");
            Console.SetCursorPosition(xOffset, yOffset);
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
