using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Games
{
    public class Game : IGame
    {
        public int Generation { get; private set; } = 0;
        public IMap Map { get; private set; }

        private readonly IGameHandler _gameHandler;

        /// <summary>
        /// Constructor for Game
        /// </summary>
        /// <param name="map">map</param>
        /// <param name="gameHandler">handler for game logic</param>
        /// <param name="printer">printer for console print logic</param>
        public Game(IMap map, IGameHandler gameHandler)
        {
            Map = map;
            _gameHandler = gameHandler;
        }

        /// <summary>
        /// Run the game for a number of iterations
        /// </summary>
        /// <param name="iterations">number of iteration a game should run</param>
        /// <param name="delay">delay for each iteration</param>
        public void Iterate()
        {
            Map = _gameHandler.CalculateNextGeneration(Map);
            Generation++;
        }

        public GameDto GetGameDto()
        {
            return new GameDto
            {
                Generation = Generation,
                Map = Map.GetMapDto()
            };
        }

        public IGame GetGame(GameDto dto, IGameHandler gameHandler)
        {
            return new Game(Map.GetMap(dto.Map), gameHandler);
        }
    }
}
