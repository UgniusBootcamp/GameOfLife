using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Cell : ICell
    {
        private int x;
        private int y;
        private bool _isAlive;

        public Cell(int x, int y, bool isAlive)
        {
            this.x = x;
            this.y = y;
            _isAlive = isAlive;
        }

        public bool IsAlive => _isAlive;

        public int X => x;

        public int Y => y;

        public bool NextState(int liveNeighbours)
        {
            return (liveNeighbours == 2 || liveNeighbours == 3);
        }
    }
}
