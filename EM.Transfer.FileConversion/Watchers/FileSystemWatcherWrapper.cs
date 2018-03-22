using System.IO;

namespace EM.Transfer.FileConversion.Watchers
{
    public class FileSystemWatcherWrapper : FileSystemWatcher, IFileSystemWatcher
    {
        public FileSystemWatcherWrapper()
        {

        }

        public FileSystemWatcherWrapper(string path) : base(path)
        {

        }

        public FileSystemWatcherWrapper(string path, string filter) : base(path, filter)
        {

        }
    }
}
