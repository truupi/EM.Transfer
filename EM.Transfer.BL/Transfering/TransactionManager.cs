using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EM.Transfer.BL.Bases;
using EM.Transfer.BL.Common.Models;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.BL.Transfering
{
    public class TransactionManager : ProviderManagerBase<Transaction>, ITransactionManager
    {
        public TransactionManager(ITransactionProvider provider, IMapper mapper) : base(provider, mapper)
        {

        }

        public async Task CreateTransactionAsync(TransactionRequest transaction)
        {
           var transactionToCreate = _mapper.Map<Transaction>(transaction);

            await _provider.CreateAsync(transactionToCreate);
        }

        public async Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsync()
        {
            var responseList = await _provider.GetAllAsync();

            return _mapper.Map<IEnumerable<TransactionResponse>>(responseList);
        }
    }
}
