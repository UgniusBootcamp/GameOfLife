namespace GameOfLife.Data.Interfaces
{
    public interface ICell
    {
        /// <summary>
        /// Constructor for Cell
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="isAlive">determines if cell is Alive (true if alive, false if not)</param>
        bool IsAlive { get; }
        int X { get; }
        int Y { get; }
    }
}
