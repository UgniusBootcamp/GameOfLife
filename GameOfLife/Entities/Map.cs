using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Map : IMap
    {
        public int Length { get; private set; }
        public int Height { get; private set; }

        private readonly Cell[,] _map;
        private readonly Random _random = new Random();

        public Map(int height, int length)
        {
            if (length < 0  || height < 0)
                throw new ArgumentException("Invalid map size");

            Length = length;
            Height = height;

            _map = new Cell[height, length];
            InitializeMap();
        }

        public Map(IMap map)
        {
            Length = map.Length;
            Height = map.Height;
            _map = new Cell[Height, Length];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    _map[i, j] = new Cell(i, j, map.GetCell(i, j).IsAlive);
                }
            }
        }

        private void InitializeMap()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int random = _random.Next(0, 2);

                    bool isAlive = Convert.ToBoolean(random);

                    _map[i, j] = new Cell(i, j, isAlive);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if(x < 0 || y < 0 || x >= Height || y >= Length)
                throw new ArgumentException("Invalid coordinates");

            return _map[x, y];
        }

        public void SetCell(Cell cell)
        {
            _map[cell.X, cell.Y] = cell;
        }

        public int Population
        {
            get
            {
                int count = 0;
                
                Parallel.For(0, Height, i =>
                {
                    Parallel.For(0, Length, j =>
                    {
                        if (_map[i, j].IsAlive)
                        {
                            Interlocked.Increment(ref count);
                        }
                    });
                });

                return count;
            }
        }

    }
}
