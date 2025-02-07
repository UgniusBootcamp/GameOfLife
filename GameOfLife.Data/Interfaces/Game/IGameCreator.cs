using GameOfLife.Data.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameCreator
    {
        IEnumerable<IGame> CreateGames();
    }
}
