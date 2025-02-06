using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Interfaces.Game
{
    public abstract class GameController(IGameReceiver gameReceiver, IGamePrinter gamePrinter)
    {
        protected readonly IGamePrinter _gamePrinter = gamePrinter;
        protected readonly IGameReceiver _gameReceiver = gameReceiver;
        public abstract void Execute();
    }
}
