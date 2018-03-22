using System;
using System.IO;
using System.Linq;
using EM.Transfer.FileConversion.FileOperations;
using EM.Transfer.FileConversion.Watchers;

namespace EM.Transfer.FileConversion.FileHandlers
{
    public abstract class FileWatcherBase : WatcherBase
    {
        protected string BackupFilePath { get; set; }
        protected string SourceFilePath { get; set; }
        protected string FileFormat { get; set; }

        private readonly IFileSystemWatcher _fileWatcher;
        private readonly IFileOperations _fileOperations;

        protected FileWatcherBase(IFileSystemWatcher fileWatcher, IFileOperations fileOperations)
        {
            _fileWatcher = fileWatcher ?? throw new ArgumentNullException(nameof(fileWatcher));
            _fileOperations = fileOperations ?? throw new ArgumentNullException(nameof(fileOperations));
        }

        public override void Watch()
        {
            _fileWatcher.Path = SourceFilePath;
            _fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            _fileWatcher.Filter = "*" + FileFormat;
            _fileWatcher.Changed += OnChanged;
            _fileWatcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            try
            {
                var fileContentList = _fileOperations.BulkLoad(e.FullPath);

                fileContentList
                    .ToList()
                    .ForEach(OnItemRead);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
