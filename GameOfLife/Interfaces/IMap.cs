using GameOfLife.Entities;

namespace GameOfLife.Interfaces
{
    public interface IMap
    {
        Cell GetCell(int x, int y);
        void SetCell(Cell cell);
        int Length { get; }
        int Height { get; }
        int Population { get; }
    }
}
