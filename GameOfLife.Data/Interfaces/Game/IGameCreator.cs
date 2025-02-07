namespace GameOfLife.Data.Interfaces.Game
{
    public interface IGameCreator
    {
        IEnumerable<IGame> CreateGames();
    }
}
