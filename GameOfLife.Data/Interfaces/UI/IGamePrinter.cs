using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Interfaces.UI
{
    public interface IGamePrinter
    {
        /// <summary>
        /// Method to print games
        /// </summary>
        /// <param name="messages">messages to print</param>
        /// <param name="games">games to print</param>
        void PrintGames(string header, string footer, IEnumerable<IGame> games);
    }
}
