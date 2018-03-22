using System;
using System.Threading.Tasks;
using EM.Transfer.BL.Common.Models;
using EM.Transfer.FileConversion.Factories;
using EM.Transfer.FileConversion.FileHandlers;
using IDALTransactionManager = EM.Transfer.DAL.Common.Interfaces.ITransactionManager;

namespace EM.Transfer.FileConversion.Managers 
{
    public class TransactionManager : ManagerBase<TransactionRequest>, ITransactionManager
    {
        private readonly IDALTransactionManager _manager;

        public TransactionManager(IFileConvertFactory<TransactionRequest> factory, IWatcher watcher, IDALTransactionManager manager)  : base(factory, watcher)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        public override async Task SaveAsync(TransactionRequest entity)
        {
            await _manager.CreateTransactionAsync(entity);
        }
    }
}
