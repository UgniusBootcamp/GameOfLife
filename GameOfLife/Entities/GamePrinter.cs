using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Interfaces;

namespace GameOfLife.Entities
{
    public class GamePrinter(IGame game) : IPrintable
    {
        private IGame _game = game;
        public void Print()
        {
            IMap _map = _game.Map;

            Console.Clear();
            Console.WriteLine($"Generation: {_game.Generation}");
            Console.WriteLine($"Population: {_game.Population}");
            Console.WriteLine("+" + new String('-', _map.Length) + "+");
            for (int i = 0; i < _map.Length; i++)
            {
                Console.Write("|");
                for (int j = 0; j < _map.Height; j++)
                {
                    Console.Write(_map.GetCell(i, j).IsAlive ? "0" : " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new String('-', _map.Length) + "+");
        }
    }
}
