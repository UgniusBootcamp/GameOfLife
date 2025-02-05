using GameOfLife.Entities;

namespace GameOfLife.Interfaces
{
    public interface IMap
    {

        /// <summary>
        /// Get cell from map
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>Cell from a map</returns>
        Cell GetCell(int x, int y);

        /// <summary>
        /// Set cell in map
        /// </summary>
        /// <param name="cell">cell to set</param>
        void SetCell(Cell cell);
        int Length { get; }
        int Height { get; }
        int Population { get; }
    }
}
