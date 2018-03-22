using System.Configuration;
using Easy.Common;
using Easy.Common.Interfaces;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Repository.Bases;

namespace EM.Transfer.DAL.Repository.Repositories
{
    public class TransactionRepositoryRest : RepositoryBaseRest<Transaction>, ITransactionRepository
    {
        private static readonly IRestClient Client = new RestClient();
        private static readonly string BaseUrl = ConfigurationManager.ConnectionStrings["TransactionConnection"].ConnectionString;

        public TransactionRepositoryRest() : base(Client, BaseUrl)
        {
        }
    }
}
