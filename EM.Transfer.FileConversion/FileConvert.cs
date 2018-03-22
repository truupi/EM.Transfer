namespace EM.Transfer.FileConversion
{
    public class FileConvert
    {
        public static string[] Convert(string content)
        {
            return content.Split(';');
        }
    }
}
