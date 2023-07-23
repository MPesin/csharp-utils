using System.IO;

namespace Utils.FileHandlers
{
    public interface IFileHandler
    {
        string Path { get; }
        
        bool Exists { get; }
        
        void Create();
        
        Stream GetStream();
    }
}