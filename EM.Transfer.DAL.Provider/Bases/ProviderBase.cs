using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.DAL.Provider.Bases
{
    public abstract class ProviderBase<TRepository, TEntity> : IProvider<TEntity>
            where TEntity : class
            where TRepository : ICustomRepository<TEntity>
    {
        protected readonly TRepository _repository;

        protected ProviderBase(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _repository.ReadAsync();

            return entities;
     
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.CreateAsync(entity);
        }

        public virtual void Dispose()
        {
                  
        }
    }
}
