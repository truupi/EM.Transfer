using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Transfer.BL.Common.Models;

namespace EM.Transfer.DAL.Common.Interfaces
{
    public interface ITransactionManager : IManager
    {
        Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync();
        Task CreateTransactionAsync(TransactionRequest transaction);
    }
}
