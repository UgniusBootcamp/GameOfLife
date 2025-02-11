namespace GameOfLife.Data.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public int Generation { get; set; }
        public required MapDto Map { get; set; }
    }
}
