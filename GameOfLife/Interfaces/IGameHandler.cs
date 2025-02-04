namespace GameOfLife.Interfaces
{
    public interface IGameHandler
    {
        IMap CalculateNextGeneration(IMap map);
    }
}
