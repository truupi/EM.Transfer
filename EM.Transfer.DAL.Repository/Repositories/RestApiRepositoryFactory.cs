using EM.Util.DataAccess.Repository;
using EM.Util.DataAccess.Repository.EntityFramework.Factory;
using System;
using System.Data.Entity;

namespace EM.Transfer.DAL.Repository.Repositories
{
    public sealed class RestApiRepositoryFactory : IRepositoryFactory
    {
        public TRepository Create<TEntity, TRepository, TContext>(string parameterName, TContext context)
            where TEntity : class
            where TRepository : IRepository<TEntity>
            where TContext : DbContext
        {
            throw new NotImplementedException();
        }

        public TRepository Create<TEntity, TRepository, TContext>(TContext context)
            where TEntity : class
            where TRepository : IRepository<TEntity>
            where TContext : DbContext
        {
            throw new NotImplementedException();
        }

        public TRepository CreateReadOnly<TEntity, TRepository, TContext>(string parameterName, TContext context)
            where TEntity : class
            where TRepository : IReadOnlyRepository<TEntity>
            where TContext : DbContext
        {
            throw new NotImplementedException();
        }

        public TRepository CreateReadOnly<TEntity, TRepository, TContext>(TContext context)
            where TEntity : class
            where TRepository : IReadOnlyRepository<TEntity>
            where TContext : DbContext
        {
            throw new NotImplementedException();
        }

        public TRepository Create<TEntity, TRepository>()
            where TEntity : class
            where TRepository : IRepository<TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
