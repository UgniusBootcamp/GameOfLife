using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Interfaces.UI
{
    public interface IOptionSelector
    {
        public int Select(string[] values);
    }
}
