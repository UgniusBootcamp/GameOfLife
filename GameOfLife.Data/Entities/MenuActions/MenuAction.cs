using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Entities.MenuActions
{
    public abstract class MenuAction
    {
        public string Name { get; set; }
        public MenuAction(string name)
        {
            Name = name;
        }

        public abstract void Execute();
    }
}
