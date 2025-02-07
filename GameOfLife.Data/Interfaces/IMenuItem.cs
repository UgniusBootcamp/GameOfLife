namespace GameOfLife.Data.Interfaces
{
    public interface IMenuItem
    {
        string Label { get; }
        void Execute();
    }
}
