using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class Map : IMap
    {
        private Cell[,] _map;
        private readonly int _length;
        private readonly int _height;
        private Random _random = new Random();

        public Map(int length, int height)
        {
            if (length < 0  || height < 0)
                throw new ArgumentException("Invalid map size");

            _length = length;
            _height = height;

            _map = new Cell[length, height];
            InitializeMap();
        }

        private void InitializeMap()
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    int random = _random.Next(0, 2);
                    _map[i, j] = new Cell(i, j, Convert.ToBoolean(random));
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            if(x < 0 || y < 0 || x >= _length || y >= _height)
                throw new ArgumentException("Invalid coordinates");

            return _map[x, y];
        }

        public void SetCell(Cell cell)
        {
            _map[cell.X, cell.Y] = cell;
        }

        public int Length => _length;
        public int Height => _height;
    }
}
