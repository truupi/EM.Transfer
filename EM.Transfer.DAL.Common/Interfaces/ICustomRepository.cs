using System.Threading.Tasks;
using EM.Util.DataAccess.Repository;

namespace EM.Transfer.DAL.Common.Interfaces
{
    public interface ICustomRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
