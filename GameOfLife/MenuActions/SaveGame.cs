using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Interfaces;

namespace GameOfLife.Data.Entities.MenuActions
{
    public class SaveGame(string name) : MenuAction(name)
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
