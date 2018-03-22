using EM.Transfer.DAL.Common.Interfaces;
using EM.Util.DataAccess.Repository;

namespace EM.Transfer.DAL.Repository.Bases
{
    public abstract class UnitOfWorkBase<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class
    {
        public abstract IRepository<TEntity> GetRepository();
    }
}
