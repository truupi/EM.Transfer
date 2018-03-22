using System.Collections.Generic;

namespace EM.Transfer.FileConversion.FileOperations
{
    public interface IFileOperations
    {
        IEnumerable<string[]> BulkLoad(string path);
    }
}
