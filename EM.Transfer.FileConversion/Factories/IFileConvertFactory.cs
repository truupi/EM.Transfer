namespace EM.Transfer.FileConversion.Factories
{
    public interface IFileConvertFactory<out TEntity> where TEntity : class
    {
        TEntity Create(string[] file);
    }
}