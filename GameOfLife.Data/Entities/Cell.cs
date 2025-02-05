using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities
{
    public class Cell : ICell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; private set; }

        /// <summary>
        /// Constructor for Cell
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="isAlive">determines if cell is Alive (true if alive, false if not)</param>
        public Cell(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
    }
}
