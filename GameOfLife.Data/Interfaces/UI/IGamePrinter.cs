using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Interfaces.UI
{
    public interface IGamePrinter
    {
        void PrintGames(string[] messages, IReadOnlyList<IGame> games);
    }
}
