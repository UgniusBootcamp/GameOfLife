using System.Runtime.CompilerServices;
using System.Text.Json;
using GameOfLife.Data.Interfaces;
using GameOfLife.Data.Interfaces.Game;

namespace GameOfLife.Data.Util
{
    public class JsonFileService : IFileService
    {
        public List<IGame> ReadGame(string fileName)
        {
            try
            {
                fileName = fileName + ".json";

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found");
                    return [];
                }

                string json = File.ReadAllText(fileName);
                var result = JsonSerializer.Deserialize<List<IGame>>(json);

                return result ?? [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read Game from file {e.Message}");
                return [];
            }
        }

        public void SaveGame(string fileName, List<IGame> games)
        {
            try
            {
                fileName = fileName + ".json";

                var gameDtos = games.Select(g => g.GetGameDto()).ToList();

                var json = JsonSerializer.Serialize(gameDtos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to save Game to file {e.Message}");
            }
        }
    }
}
