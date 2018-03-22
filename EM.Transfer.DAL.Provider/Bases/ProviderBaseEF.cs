using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.DAL.Provider.Bases
{
    public abstract class ProviderBaseEf<TRepository, TEntity> : ProviderBase<TRepository, TEntity>
            where TEntity : class
            where TRepository : ICustomRepository<TEntity>
    {
        protected readonly IUnitOfWork<TEntity> _unitOfWork;
        protected readonly TransactionDbContext _dbContext;

        protected ProviderBaseEf(TransactionDbContext dbContext, TRepository repository, IUnitOfWork<TEntity> unitOfWork)
            : base(repository)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
    }
}
