namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameSaver
    {
        /// <summary>
        /// Method to save games
        /// </summary>
        /// <param name="games">games to save</param>
        void SaveGames(IEnumerable<IGame> games);
    }
}
