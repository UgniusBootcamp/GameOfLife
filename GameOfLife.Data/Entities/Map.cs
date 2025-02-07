using System.Text;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities
{
    public class Map : IMap
    {
        public int Length { get; private set; }
        public int Height { get; private set; }

        private readonly Cell[,] _map;
        private readonly Random _random = new Random();

        /// <summary>
        /// Constructor for Map
        /// </summary>
        /// <param name="height">height of map</param>
        /// <param name="length">length of map</param>
        /// <exception cref="ArgumentException">if lenght or height value is less than zero</exception>
        public Map(int height, int length)
        {
            if (length < 0  || height < 0)
                throw new ArgumentException(GameConstants.InvalidMapSizeMessage);

            Length = length;
            Height = height;

            _map = new Cell[height, length];
            InitializeMap();
        }

        /// <summary>
        /// Constructor for Map
        /// </summary>
        /// <param name="map">copy of map</param>
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

        /// <summary>
        /// Initialize the map with random values
        /// </summary>
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

        /// <summary>
        /// Get cell from map
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <returns>Cell from a map</returns>
        /// <exception cref="ArgumentException">if coordinates are not from map</exception>
        public Cell GetCell(int x, int y)
        {
            if(x < 0 || y < 0 || x >= Height || y >= Length)
                throw new ArgumentException(GameConstants.InvalidCellPositionMessage);

            return _map[x, y];
        }

        /// <summary>
        /// Set cell in map
        /// </summary>
        /// <param name="cell">cell to set</param>
        public void SetCell(Cell cell)
        {
            _map[cell.X, cell.Y] = cell;
        }

        public MapDto GetMapDto()
        {
            return new MapDto
            {
                Height = Height,
                Length = Length,
                Cells = CellsToString()
            };
        }

        public Map(MapDto dto)
        {
            Length = dto.Length;
            Height = dto.Height;
            _map = new Cell[Height, Length];

            for (int i = 0; i < dto.Height; i++)
            {
                for (int j = 0; j < dto.Length; j++)
                {
                    _map[i,j] = new Cell(i, j, dto.Cells[i][j] == 1);
                }
            }
        }

        private List<string> CellsToString()
        {
            var list = new List<string>();

            for (int i = 0; i < Height; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < Length; j++)
                {
                    sb.Append(_map[i, j].IsAlive ? "1" : "0");
                }
                list.Add(sb.ToString());
            }
            return list;
        }
           
        /// <summary>
        /// Get the alive cells of the map count
        /// </summary>
        public int Population
        {
            get
            {
                int count = 0;
                
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        if (_map[i, j].IsAlive)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }
    }
}
