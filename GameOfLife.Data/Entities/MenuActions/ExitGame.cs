using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Entities.MenuActions
{
    public class ExitGame(string name) : MenuAction(name)
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
