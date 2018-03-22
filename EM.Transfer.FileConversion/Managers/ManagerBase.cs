using System;
using System.Threading.Tasks;
using EM.Transfer.FileConversion.EventArgs;
using EM.Transfer.FileConversion.Factories;
using EM.Transfer.FileConversion.FileHandlers;

namespace EM.Transfer.FileConversion.Managers
{
    public abstract class ManagerBase<TEntity> : IManager<TEntity>
        where TEntity : class
    {
        private readonly IFileConvertFactory<TEntity> _factory;
        private readonly IWatcher _watcher;

        protected ManagerBase(IFileConvertFactory<TEntity> factory, IWatcher watcher)
        {
            _watcher = watcher ?? throw new ArgumentNullException(nameof(watcher));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        private async Task OnItemRead(string[] properties)
        {
            var entity = _factory.Create(properties);
            await SaveAsync(entity);
        }

        public abstract Task SaveAsync(TEntity entity);

        public void Start()
        {
            _watcher.Watch();
            _watcher.ItemRead += WatcherItemRead;            
        }

        private void WatcherItemRead(object sender, OnItemReadEventArgs e) => Task.Run(() => OnItemRead(e.Properties));

        public void Stop()
        {
            _watcher.ItemRead -= WatcherItemRead;
            _watcher.Dispose();
        }
    }
}
