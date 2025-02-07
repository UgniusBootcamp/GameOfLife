namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameLoader
    {
        IEnumerable<IGame> LoadGames();
    }
}
