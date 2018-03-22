using System;
using AutoMapper;
using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.BL.Bases
{
    public abstract class ProviderManagerBase<TEntity> : ManagerBase
        where TEntity : class
    {
        protected readonly IProvider<TEntity> _provider;

        protected ProviderManagerBase(IProvider<TEntity> provider, IMapper mapper) : base(mapper)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
