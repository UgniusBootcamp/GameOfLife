using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Interfaces.UI
{
    public interface IOutputHandler
    {
        public void Output(string message);
        public void Output(string[] messages);
        public void Clear();
    }
}
