using System;
using System.IO;
using System.Reflection;

namespace Utils.FileHandlers
{
    public class EmbeddedResourceHandler : IFileHandler
    {
        private readonly Type _callerType;

        public EmbeddedResourceHandler(string path, Type callerType)
        {
            _callerType = callerType;
            Path = path;
        }

        public string Path { get; }

        public bool Exists
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                return assembly.GetManifestResourceStream(Path) == null;
            }
        }

        public Stream GetStream()
        {
            var assembly = Assembly.GetAssembly(_callerType);
            return assembly.GetManifestResourceStream(Path) ??
                   throw new FileLoadException();
        }

        public void Create()
        {
            // do nothing
        }
    }
}