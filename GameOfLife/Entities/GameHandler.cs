using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class GameHandler(IRule rule) : IGameHandler
    {
        private readonly IRule _rule = rule;

        public IMap CalculateNextGeneration(IMap map)
        {
            int length = map.Length;
            int height = map.Height;

            var nextMap = new Map(map);

            Parallel.For(0, height, i=>
            {
                Parallel.For(0, length, j =>
                {
                    var cell = map.GetCell(i, j);
                    var aliveNeighbours = CountAliveNeighbours(i, j, map);

                    var nextState = _rule.ShouldLive(cell.IsAlive, aliveNeighbours);

                    nextMap.SetCell(new Cell(i, j, nextState));
                });
            });      

            return nextMap;
        }

        private static int CountAliveNeighbours(int x, int y, IMap map)
        {
            int count = 0;

            Parallel.For(x - 1, x + 2, i =>
            {
                Parallel.For(y - 1, y + 2, j =>
                {
                    if (i == x && j == y || i < 0 || j < 0 || i >= map.Height || j >= map.Length)
                    {
                        return;
                    }
                    if (map.GetCell(i, j).IsAlive)
                    {
                        Interlocked.Increment(ref count);
                    }
                });
            });        

            return count;
        }
    }
}
