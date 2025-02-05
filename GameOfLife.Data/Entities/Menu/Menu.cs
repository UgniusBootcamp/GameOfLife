using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Entities.MenuActions;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.Menu
{
    public abstract class Menu(MenuAction[] actions)
    {
        public MenuAction[] Actions { get; protected set; } = actions;

        public void ShowMenu()
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Actions[i].Name}");
            }
        }
    }
}
