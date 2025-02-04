using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;
using GameOfLife.Services;

namespace GameOfLife.Entities
{
    public class Map : IMap, IPrintable
    {
        private Cell[,] _map;
        private readonly int _length;
        private readonly int _height;
        private Random _random = new Random();

        public Map(int length, int height)
        {
            if (length < 0 || length > int.MaxValue || height < 0 || height > int.MaxValue)
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
            if(x < 0 || y < 0 || x > _length || y > _height)
                throw new ArgumentException("Invalid coordinates");

            return _map[x, y];
        }

        public int Length => _length;
        public int Height => _height;

        public void Print()
        {
            Console.WriteLine("+" + new String('-', _length) + "+");
            for(int i = 0; i < _length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _height; j++)
                {
                    Console.Write(_map[i, j].IsAlive ? "0" : " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new String('-', _length) + "+");
        }

        public void SetCell(Cell cell)
        {
            _map[cell.X, cell.Y] = cell;
        }
    }
}
