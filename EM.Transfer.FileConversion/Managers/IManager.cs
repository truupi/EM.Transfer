using System.Threading.Tasks;

namespace EM.Transfer.FileConversion.Managers
{
    public interface IManager<in TEntity>
        where TEntity : class
    {
        void Start();
        void Stop();
        Task SaveAsync(TEntity entity);
    }
}
