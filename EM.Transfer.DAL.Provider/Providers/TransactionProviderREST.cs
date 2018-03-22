using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Provider.Bases;

namespace EM.Transfer.DAL.Provider.Providers
{
    public class TransactionProviderRest : ProviderBaseRest<ITransactionRepository, Transaction>, ITransactionProvider
    {
        public TransactionProviderRest(ITransactionRepository transactionRepository) : base(transactionRepository)
        {

        }
    }
}
