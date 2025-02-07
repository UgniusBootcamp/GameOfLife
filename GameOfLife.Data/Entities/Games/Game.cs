using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Games
{
    public class Game : GameBase
    {
        public Game(IMap map, IGameLogic gameHandler) : base(map, gameHandler) { }
        public Game(int generation, IMap map, IGameLogic gameHandler) : base(generation, map, gameHandler) { }

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
