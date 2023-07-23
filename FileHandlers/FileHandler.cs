using System;
using System.IO;

namespace Utils.FileHandlers
{
    public class FileHandler : IFileHandler
    {
        public FileHandler(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException(@"Value cannot be null or empty.", nameof(path));

            Path = path;
        }

        public string Path { get; }

        public bool Exists => File.Exists(Path);

        public Stream GetStream() => File.Open(Path, FileMode.Open, FileAccess.ReadWrite);

        public void Create()
        {
            if (!Exists)
            {
                using var stream = File.Create(Path);
            }
        }
    }
}