using System;
using EM.Transfer.FileConversion.EventArgs;

namespace EM.Transfer.FileConversion.FileHandlers
{
    public interface IWatcher : IDisposable
    {
        event EventHandler<OnItemReadEventArgs> ItemRead;
        void Watch();
    }
}
