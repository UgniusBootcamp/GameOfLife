using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;

namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGame
    {

        int Generation { get; }
        IMap Map { get; }

        /// <summary>
        /// Method to transfer data from Game to GameDto
        /// </summary>
        /// <returns>transformed object</returns>
        GameDto GetGameDto();

        /// <summary>
        /// Method to perform one iteration of a game
        /// </summary>
        void Iterate();
    }
}
