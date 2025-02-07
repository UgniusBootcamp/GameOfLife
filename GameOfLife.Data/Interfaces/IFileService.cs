using GameOfLife.Data.Dto;

namespace GameOfLife.Data.Interfaces
{
    public interface IFileService
    {
        void SaveGame(string fileName, IEnumerable<GameDto> games);
        List<GameDto> ReadGame(string fileName);
    }
}
