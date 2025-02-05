using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Entities.MenuActions;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.Menu
{
    public class StartMenu(MenuAction[] actions) : Menu(actions)
    {
    }
}
