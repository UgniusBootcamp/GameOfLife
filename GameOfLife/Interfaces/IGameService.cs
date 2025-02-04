using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Interfaces
{
    public interface IGameService
    {
        void Run(int iterations, int delay = 1000);
    }
}
