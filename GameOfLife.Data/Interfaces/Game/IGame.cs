using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;

namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGame
    {

        int Generation { get; }
        IMap Map { get; }

        GameDto GetGameDto();
        void Iterate();
    }
}
