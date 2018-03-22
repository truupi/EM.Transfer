using EM.Transfer.DAL.Common.Interfaces;
using EM.Util.DataAccess.Repository;
using EM.Util.DataAccess.Repository.EntityFramework.Factory;

namespace EM.Transfer.DAL.Repository.Bases
{
    public abstract class UnitOfWorkBaseEf<TEntity, TRepository, TContext> : UnitOfWorkBase<TEntity>, IUnitOfWorkEf
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly TransactionDbContext _dbContext;
        protected readonly IRepositoryFactory _repositoryFactory;
        protected readonly IRepository<TEntity> _repository;

        protected UnitOfWorkBaseEf(TransactionDbContext dbContext, IRepositoryFactory repositoryFactory)
        {
            _dbContext = dbContext;
            _repositoryFactory = repositoryFactory;
            _repository = _repositoryFactory.Create<TEntity, TRepository, TransactionDbContext>(_dbContext);
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
