using System;
using AutoMapper;

namespace EM.Transfer.BL.Bases
{
    public abstract class ManagerBase : IDisposable
    {
        protected readonly IMapper _mapper;

        protected ManagerBase(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {

            }
        }
    }
}
