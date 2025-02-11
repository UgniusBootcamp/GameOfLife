using GameOfLife.Data.Constants;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Entities.Games
{
    public class Game : GameBase
    {
        public Game(int id, IMap map, IGameLogic gameHandler) : base(id, map, gameHandler) { }
        public Game(int id, int generation, IMap map, IGameLogic gameHandler) : base(id, generation, map, gameHandler) { }

        /// <summary>
        /// Method to perform one iteration of a game
        /// </summary>
        public override void Iterate()
        {
            Map = _gameHandler.CalculateNextGeneration(Map);
            Generation++;
        }
    }
}
