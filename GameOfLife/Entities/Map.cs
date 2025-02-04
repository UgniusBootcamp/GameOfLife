using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Map : IMap
    {
        public int Length { get; private set; }
        public int Height { get; private set; }
        public int Population { get; private set; }

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

        private void InitializeMap()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    int random = _random.Next(0, 2);

                    bool isAlive = Convert.ToBoolean(random);

                    if (isAlive)
                        Population++;

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
            var previousCellState = GetCell(cell.X, cell.Y);

            if(previousCellState.IsAlive && !cell.IsAlive)
                Population--;
            else if (!previousCellState.IsAlive && cell.IsAlive)
                Population++;

            _map[cell.X, cell.Y] = cell;
        }
    }
}
