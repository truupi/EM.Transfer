using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Provider.Bases;

namespace EM.Transfer.DAL.Provider.Providers
{
    public class TransactionProviderEf : ProviderBaseEf<ITransactionRepository, Transaction>, ITransactionProvider
    {
        private readonly ITransactionUnitOfWork _transactionUnitOfWork;

        public TransactionProviderEf(TransactionDbContext dbContext, ITransactionUnitOfWork transactionUnitOfWork, ITransactionRepository transactionRepository, ITransactionUnitOfWork transactionUnitOfWork1) 
            : base(dbContext, transactionRepository, transactionUnitOfWork)
        {
            _transactionUnitOfWork = transactionUnitOfWork1;
        }
    }
}
