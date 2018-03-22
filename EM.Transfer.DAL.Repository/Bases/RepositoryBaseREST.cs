using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Easy.Common.Interfaces;
using EM.Transfer.DAL.Common.Interfaces;
using Newtonsoft.Json;

namespace EM.Transfer.DAL.Repository.Bases
{
    public abstract class RepositoryBaseRest<TEntity> : ReadOnlyRespositoryBaseRest<TEntity>, ICustomRepository<TEntity>
        where TEntity : class
    {
        protected RepositoryBaseRest(IRestClient client, string baseUrl) : base(client, baseUrl)
        {
            
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            var entityJson = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            await _client.PostAsync(_baseUrl, entityJson);
        }

        public virtual void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
