using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class MapPrinter(IMap map) : IPrintable
    {
        private IMap _map = map;

        public void Print()
        {
            Console.WriteLine($"Population: {_map.Population}");
            Console.WriteLine("+" + new String('-', _map.Length) + "+");
            for (int i = 0; i < _map.Height; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _map.Length; j++)
                {
                    Console.Write(_map.GetCell(i, j).IsAlive ? "0" : " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new String('-', _map.Length) + "+");
        }
    }
}
