namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameSaver
    {
        void SaveGames(List<IGame> games);
    }
}
