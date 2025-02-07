using System.Runtime.CompilerServices;
using System.Text.Json;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class JsonFileService(IOutputHandler outputHandler) : IFileService
    {
        private readonly string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GameConstants.GameSaveDirectory) + "\\";
        private readonly IOutputHandler _outputHandler = outputHandler;

        public List<GameDto> ReadGame(string fileName)
        {
            try
            {
                fileName = dir + fileName + ".json";

                if (!File.Exists(fileName))
                {
                    _outputHandler.Output($"The file {fileName} does not exist.");
                    return [];
                }

                string json = File.ReadAllText(fileName);
                var result = JsonSerializer.Deserialize<List<GameDto>>(json);

                return result ?? [];
            }
            catch (Exception e)
            {
                _outputHandler.Output($"Failed to read Game from file: {e.Message}");
                return [];
            }
        }

        public void SaveGame(string fileName, IEnumerable<GameDto> games)
        {
            try
            {
                DirectoryCheck();

                fileName = dir + fileName + ".json";

                var json = JsonSerializer.Serialize(games, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
            catch (Exception e)
            {
                _outputHandler.Output($"Failed to save Game to file {e.Message}");
            }
        }

        private void DirectoryCheck()
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
