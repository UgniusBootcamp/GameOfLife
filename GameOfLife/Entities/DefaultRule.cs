using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class DefaultRule : IRule
    {
        public bool ShouldLive(bool isAlive, int liveNeighbors)
        {
            if (isAlive)
                return (liveNeighbors == 2 || liveNeighbors == 3);

            return liveNeighbors == 3;
        }
    }
}
