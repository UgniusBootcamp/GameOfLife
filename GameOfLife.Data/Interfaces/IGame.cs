using GameOfLife.Data.Constants;

namespace GameOfLife.Data.Interfaces
{
    public interface IGame
    {
        int Generation { get; }
        IMap Map { get; }
        void Iterate();
    }
}
