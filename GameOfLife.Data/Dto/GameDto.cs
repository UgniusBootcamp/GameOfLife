namespace GameOfLife.Data.Dto
{
    public class GameDto
    {
        public int Generation { get; set; }
        public required MapDto Map { get; set; }
    }
}
