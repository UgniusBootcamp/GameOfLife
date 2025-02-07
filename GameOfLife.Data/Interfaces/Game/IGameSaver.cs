namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameSaver
    {
        void SaveGames(IEnumerable<IGame> games);
    }
}
