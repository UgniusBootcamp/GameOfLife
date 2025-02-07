using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Games
{
    public class Game(IMap map, IGameLogic gameHandler) : GameBase(map, gameHandler)
    {
        /// <summary>
        /// Run the game for a number of iterations
        /// </summary>
        /// <param name="iterations">number of iteration a game should run</param>
        /// <param name="delay">delay for each iteration</param>
        public override void Iterate()
        {
            Map = _gameHandler.CalculateNextGeneration(Map);
            Generation++;
        }
    }
}
