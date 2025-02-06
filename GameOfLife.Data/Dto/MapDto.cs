using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Data.Dto
{
    public class MapDto
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public required List<string> Cells { get; set; }
    }
}
