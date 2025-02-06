using GameOfLife.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Interfaces
{
    public interface IGameControllerReceiver
    {
        GameController GetGameController();
    }
}
