using System;
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

        /// <summary>
        /// Game Base consturctor
        /// </summary>
        /// <param name="map">map</param>
        /// <param name="gameHandler">game logic</param>
        public GameBase(IMap map, IGameLogic gameHandler)
        {
            Map = map;
            _gameHandler = gameHandler;
        }

        /// <summary>
        /// Game base constructor for loading game (which already has been played)
        /// </summary>
        /// <param name="generation">generations</param>
        /// <param name="map">map</param>
        /// <param name="gameHandler">game logic</param>
        public GameBase(int generation, IMap map, IGameLogic gameHandler)
        {
            Generation = generation;
            Map = map;
            _gameHandler = gameHandler;
        }

        /// <summary>
        /// Method to transfer data from Game to GameDto
        /// </summary>
        /// <returns>transformed object</returns>
        public virtual GameDto GetGameDto()
        {
            return new GameDto
            {
                Generation = Generation,
                Map = Map.GetMapDto()
            };
        }

        /// <summary>
        /// Method for one time game interation
        /// </summary>
        public abstract void Iterate();
    }
}
