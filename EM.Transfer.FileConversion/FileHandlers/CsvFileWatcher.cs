using EM.Transfer.FileConversion.FileOperations;
using EM.Transfer.FileConversion.Watchers;

namespace EM.Transfer.FileConversion.FileHandlers
{
    public class CsvFileWatcher : FileWatcherBase
    {
        public CsvFileWatcher(IFileSystemWatcher watcher, IFileOperations fileOperations) : base(watcher, fileOperations)
        {
            SourceFilePath = @"C:\EclectiqTest\receiving";
            BackupFilePath = @"C:\EclectiqTest\backup";
            FileFormat = ".csv";
        }
    }
}
