using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Cell : ICell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; private set; }

        public Cell(int x, int y, bool isAlive)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
        }
    }
}
