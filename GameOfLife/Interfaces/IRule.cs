using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Interfaces
{
     public interface IRule
    {
        bool ShouldLive(bool isAlive, int liveNeighbors);
    }
}
