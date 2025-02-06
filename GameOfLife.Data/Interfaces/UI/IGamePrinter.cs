using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Interfaces.UI
{
    public interface IGamePrinter
    {
        void PrintGames(string[] messages, IReadOnlyList<IGame> games);
    }
}
