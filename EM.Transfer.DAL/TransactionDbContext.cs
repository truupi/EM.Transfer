using System.Data.Entity;
using EM.Transfer.DAL.Common.Entities;

namespace EM.Transfer.DAL
{
    public class TransactionDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public TransactionDbContext(string connectionString) : base(connectionString)
        {

        }

        public TransactionDbContext() : this("TransactionDatabase")
        {

        }

        public static TransactionDbContext Create()
        {
            return new TransactionDbContext();
        }
    }
}
