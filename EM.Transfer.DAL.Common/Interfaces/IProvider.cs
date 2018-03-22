using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Transfer.DAL.Common.Interfaces
{
    public interface IProvider<TEntity> : IDisposable
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
    }
}
