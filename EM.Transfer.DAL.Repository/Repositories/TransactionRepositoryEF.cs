using System.Threading.Tasks;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Util.DataAccess.Repository.EntityFramework;

namespace EM.Transfer.DAL.Repository.Repositories
{
    public class TransactionRepositoryEf : RepositoryBase<Transaction, TransactionDbContext>, ITransactionRepository
    {
        public TransactionRepositoryEf(TransactionDbContext context) : base(context)
        {
        
        }

        public async Task CreateAsync(Transaction entity)
        {
            await Task.Run(() => _context.Transactions.Add(entity));
        }
    }
}
