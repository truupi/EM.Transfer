using EM.Util.DataAccess.Repository;

namespace EM.Transfer.DAL.Common.Interfaces
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        IRepository<TEntity> GetRepository();
    }
}
