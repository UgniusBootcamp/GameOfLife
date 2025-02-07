using GameOfLife.Data.Constants;

namespace GameOfLife.Data.Util
{
    /// <summary>
    /// Singleton Filesystem
    /// </summary>
    public class FileSystem
    {
        /// <summary>
        /// FileSystem instance
        /// </summary>
        private static readonly FileSystem instance = new FileSystem();
        
        /// <summary>
        /// FileSystem constructor
        /// </summary>
        private FileSystem(){ }

        /// <summary>
        /// File system instance
        /// </summary>
        public static FileSystem Instance => instance;

        /// <summary>
        /// Method to get recent files from directory
        /// </summary>
        /// <param name="dirPath">directory path</param>
        /// <param name="fileExtension">file extensions to get</param>
        /// <param name="numb">how many files to get</param>
        /// <returns>recent files</returns>
        public string[] GetDirFiles(string dirPath = GameConstants.GameSaveDirectory , string fileExtension = GameConstants.DefaultFileExtension,  int numb = GameConstants.DefaultFileSelectionNumber)
        {
            var files = Directory.GetFiles(dirPath, $"*.{fileExtension}");

            var recentFiles = files
                .Select(f => new FileInfo(f))
                .OrderByDescending(f => f.LastWriteTime)
                .Take(numb)
                .ToList();

            var fileNames = recentFiles.Select(f => f.Name).ToArray();

            return fileNames;
        }
    }
}
