using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.DAL.Provider.Bases
{
    public abstract class ProviderBaseRest<TRepository, TEntity> : ProviderBase<TRepository, TEntity>
            where TEntity : class
            where TRepository : ICustomRepository<TEntity>
    {
        protected ProviderBaseRest(TRepository repository) : base(repository)
        {
        }
    }
}
