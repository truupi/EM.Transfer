using System;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Util.DataAccess.Repository;

namespace EM.Transfer.DAL.Repository.UnitOfWorks
{
    public class TransactionUnitOfWorkRest : ITransactionUnitOfWork
    {
        public IRepository<Transaction> GetRepository()
        {
            throw new NotImplementedException();
        }
    }
}
