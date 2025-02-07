using System.Text.Json;
using GameOfLife.Data.Constants;
using GameOfLife.Data.Dto;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.UI;

namespace GameOfLife.Data.Util
{
    public class JsonFileService(IOutputHandler outputHandler) : IFileService
    {
        private readonly string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GameConstants.GameSaveDirectory) + "\\";
        private readonly IOutputHandler _outputHandler = outputHandler;

        /// <summary>
        /// Method to read games which are in json format
        /// </summary>
        /// <param name="fileName">name of file</param>
        /// <returns>games</returns>
        public List<GameDto> ReadGame(string fileName)
        {
            try
            {
                fileName = dir + fileName;

                if (!File.Exists(fileName))
                {
                    _outputHandler.Output($"{GameConstants.FileNotFoundMessage} {fileName}");
                    return [];
                }

                string json = File.ReadAllText(fileName);
                var result = JsonSerializer.Deserialize<List<GameDto>>(json);

                return result ?? [];
            }
            catch (Exception e)
            {
                _outputHandler.Output($"{GameConstants.FailedToReadGameMessage} {e.Message}");
                return [];
            }
        }

        /// <summary>
        /// Method to save games in json format
        /// </summary>
        /// <param name="fileName">name of file to save</param>
        /// <param name="games">games to save</param>
        public void SaveGame(string fileName, IEnumerable<GameDto> games)
        {
            try
            {
                DirectoryCheck();

                fileName = dir + fileName + GameConstants.JsonExtension;

                var json = JsonSerializer.Serialize(games, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
            catch (Exception e)
            {
                _outputHandler.Output($"{GameConstants.FailedToSaveGameMessage} {e.Message}");
            }
        }

        /// <summary>
        /// Helper to check if directory exists
        /// </summary>
        private void DirectoryCheck()
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
