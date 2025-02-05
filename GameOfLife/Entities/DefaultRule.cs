using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class DefaultRule : IRule
    {
        private const int aliveNeighborCount = 2; // value for alive cell to stay alive
        private const int aliveNeighborCount2 = 3; // value for alive cell to stay alive
        private const int resurrectionNeighborCount = 3; // value for dead cell to become alive


        /// <summary>
        /// Determines if a cell should live or die based on the number of live neighbors
        /// </summary>
        /// <param name="isAlive">previous cell state</param>
        /// <param name="liveNeighbors">number of alive neighbors</param>
        /// <returns>cell is or is not alive</returns>
        /// 
        public bool ShouldLive(bool isAlive, int liveNeighbors)
        {
            if (isAlive)
                return (liveNeighbors == aliveNeighborCount || liveNeighbors == aliveNeighborCount2;

            return liveNeighbors == resurrectionNeighborCount;
        }
    }
}
