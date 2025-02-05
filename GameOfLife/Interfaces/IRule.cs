namespace GameOfLife.Interfaces
{
     public interface IRule
    {
        /// <summary>
        /// Determines if a cell should live or die
        /// </summary>
        /// <param name="isAlive">previous cell state</param>
        /// <param name="liveNeighbors">number of alive neighbors</param>
        ///<returns>cell is or is not alive</returns>
        bool ShouldLive(bool isAlive, int liveNeighbors);
    }
}
