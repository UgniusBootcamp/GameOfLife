using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Data.Constants;

namespace GameOfLife.Data.Util
{
    public class FileSystem
    {
        private static readonly FileSystem instance = new FileSystem();
        private FileSystem(){ }
        public static FileSystem Instance => instance;
        public string[] GetDirFiles(string dirPath = GameConstants.GameSaveDirectory , string fileExtension = "json",  int numb = 5)
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
