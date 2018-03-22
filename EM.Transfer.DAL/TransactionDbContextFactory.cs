using System.Data.Entity.Infrastructure;

namespace EM.Transfer.DAL
{
    public class TransactionDbContextFactory : IDbContextFactory<TransactionDbContext>
    {
        public TransactionDbContext Create()
        {
            return TransactionDbContext.Create();
        }
    }
}
