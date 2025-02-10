using System;
namespace GameOfLife.Data.Dto
{
    public class MapDto
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public required List<string> Cells { get; set; }
    }
}
