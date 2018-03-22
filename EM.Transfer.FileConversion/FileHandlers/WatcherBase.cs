using System;
using EM.Transfer.FileConversion.EventArgs;

namespace EM.Transfer.FileConversion.FileHandlers
{
    public abstract class WatcherBase : IWatcher
    {
        public event EventHandler<OnItemReadEventArgs> ItemRead;

        public virtual void Dispose()
        {
           
        }

        protected void OnItemRead(string[] properties)
        {
            ItemRead?.Invoke(this, new OnItemReadEventArgs { Properties = properties });
        }

        public abstract void Watch();
    }
}
