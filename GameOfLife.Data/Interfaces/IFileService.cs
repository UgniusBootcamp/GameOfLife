using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Interfaces
{
    public interface IFileService
    {
        void SaveGame(string fileName, IEnumerable<GameDto> games);
        List<GameDto> ReadGame(string fileName);
    }
}
