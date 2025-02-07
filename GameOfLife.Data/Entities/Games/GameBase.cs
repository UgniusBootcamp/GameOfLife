using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Games
{
    public abstract class GameBase : IGame
    {
        public int Generation { get; protected set; } = 0;
        public IMap Map { get; protected set; }

        protected readonly IGameLogic _gameHandler;

        public GameBase(IMap map, IGameLogic gameHandler)
        {
            Map = map;
            _gameHandler = gameHandler;
        }

        public virtual GameDto GetGameDto()
        {
            return new GameDto
            {
                Generation = Generation,
                Map = Map.GetMapDto()
            };
        }

        public abstract void Iterate();
    }
}
