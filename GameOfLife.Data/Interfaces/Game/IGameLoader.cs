namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameLoader
    {
        /// <summary>
        /// Method to load previous games
        /// </summary>
        /// <returns>previous games</returns>
        IEnumerable<IGame> LoadGames();
    }
}
