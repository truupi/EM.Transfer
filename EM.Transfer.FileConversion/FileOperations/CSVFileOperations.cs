using System.Collections.Generic;
using System.IO;

namespace EM.Transfer.FileConversion.FileOperations
{
    public class CsvFileOperations : IFileOperations
    {
        public IEnumerable<string[]> BulkLoad(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream))
                {
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        yield return currentLine.Split(';');
                    }
                }
            }
        }
    }
}
