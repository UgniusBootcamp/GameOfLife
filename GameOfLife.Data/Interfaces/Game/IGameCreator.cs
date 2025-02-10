namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameCreator
    {
        /// <summary>
        /// Method to Create games
        /// </summary>
        /// <returns>Created games</returns>
        IEnumerable<IGame> CreateGames();
    }
}
