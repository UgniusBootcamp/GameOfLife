using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Dto
{
    public class GameDto
    {
        public int Generation { get; set; }
        public required MapDto Map { get; set; }
    }
}
