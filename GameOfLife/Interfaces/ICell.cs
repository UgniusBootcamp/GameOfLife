using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Interfaces
{
    public interface ICell
    {
        bool NextState(int liveNeighbours);
        bool IsAlive { get; }
        int X { get; }
        int Y { get; }
    }
}
