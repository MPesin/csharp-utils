using System;
using System.IO;

namespace Utils.FileHandlers
{
    public class DirectoryHandler : IFileHandler
    {
        public DirectoryHandler(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException(@"Value cannot be null or empty.", nameof(path));
            Path = path;
        }

        public string Path { get; }

        public bool Exists => Directory.Exists(Path);

        public Stream GetStream() => File.Open(Path, FileMode.Open, FileAccess.Read);

        public void Create()
        {
            if (!Exists)
            {
                Directory.CreateDirectory(Path);
            }
        }
    }
}