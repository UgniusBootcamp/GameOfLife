using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class DefaultRule : IRule
    {
        /// <summary>
        /// Determines if a cell should live or die based on the number of live neighbors
        /// </summary>
        /// <param name="isAlive">previous cell state</param>
        /// <param name="liveNeighbors">number of alive neighbors</param>
        /// <returns>cell is or is not alive</returns>
        public bool ShouldLive(bool isAlive, int liveNeighbors)
        {
            if (isAlive)
                return (liveNeighbors == 2 || liveNeighbors == 3);

            return liveNeighbors == 3;
        }
    }
}
