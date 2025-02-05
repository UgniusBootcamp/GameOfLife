using GameOfLife.Data.Constants;

namespace GameOfLife.Data.Interfaces
{
    public interface IGame
    {
        int Generation { get; }
        IMap Map { get; }

        /// <summary>
        /// Run the game for a number of iterations
        /// </summary>
        /// <param name="iterations">number of iteration a game should run</param>
        /// <param name="delay">delay for each iteration</param>
        void Run(int iterations, int delay = GameConstants.DefaultDelay);
    }
}
