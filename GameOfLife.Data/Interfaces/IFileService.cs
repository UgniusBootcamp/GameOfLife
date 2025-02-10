using GameOfLife.Data.Dto;

namespace GameOfLife.Data.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Method to save games
        /// </summary>
        /// <param name="fileName">name of file where games will be saved</param>
        /// <param name="games">games to save</param>
        void SaveGame(string fileName, IEnumerable<GameDto> games);

        /// <summary>
        /// Method to read gaves
        /// </summary>
        /// <param name="fileName">name of file where games are stored</param>
        /// <returns>games</returns>
        List<GameDto> ReadGame(string fileName);
    }
}
