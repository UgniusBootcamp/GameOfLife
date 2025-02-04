using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class GameHandler : IGameHandler
    {
        public IMap CalculateNextGeneration(IMap map)
        {
            int length = map.Length;
            int height = map.Height;

            var nextMap = new Map(height, length);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    var cell = map.GetCell(i, j);
                    var aliveNeighbours = CountAliveNeighbours(i, j, map);

                    var nextState = cell.NextState(aliveNeighbours);

                    nextMap.SetCell(new Cell(i, j, nextState));
                }
            }

            return nextMap;
        }

        private static int CountAliveNeighbours(int x, int y, IMap map)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= map.Height || j >= map.Length)
                    {
                        continue;
                    }
                    if (map.GetCell(i, j).IsAlive)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
