namespace GameOfLife.Data.Interfaces
{
    public interface IGameHandler
    {
        /// <summary>
        /// Constructor for GameHandler
        /// </summary>
        /// <param name="map">map</param>
        /// <returns>calculated map for next generation</returns>
        IMap CalculateNextGeneration(IMap map);
    }
}
