using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Game
{
    public class GameHandler(IRule rule) : IGameHandler
    {
        private readonly IRule _rule = rule;

        /// <summary>
        /// Constructor for GameHandler
        /// </summary>
        /// <param name="map">map</param>
        /// <returns>calculated map for next generation</returns>
        public IMap CalculateNextGeneration(IMap map)
        {
            int length = map.Length;
            int height = map.Height;

            var nextMap = new Map(map);

            Parallel.For(0, height, i =>
            {
                for (int j = 0; j < length; j++)
                {
                    var cell = map.GetCell(i, j);
                    var aliveNeighbours = CountAliveNeighbours(i, j, map);

                    var nextState = _rule.ShouldLive(cell.IsAlive, aliveNeighbours);

                    nextMap.SetCell(new Cell(i, j, nextState));
                }
            });

            return nextMap;
        }

        /// <summary>
        /// Count the number of alive neighbours
        /// </summary>
        /// <param name="x">cell coordinate x</param>
        /// <param name="y">cell coordinate y</param>
        /// <param name="map">current map</param>
        /// <returns>count of alive neighbors</returns>
        private static int CountAliveNeighbours(int x, int y, IMap map)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= map.Height || j >= map.Length)
                        continue;

                    if (map.GetCell(i, j).IsAlive)
                        count++;
                }
            }

            return count;
        }
    }
}
