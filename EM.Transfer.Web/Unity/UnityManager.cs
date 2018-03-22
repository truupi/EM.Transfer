using System;
using System.Diagnostics;
using System.Web.Http;
using AutoMapper;
using EM.Transfer.BL.Common.Models;
using EM.Transfer.BL.Transfering;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Provider.Providers;
using EM.Transfer.DAL.Repository.Repositories;
using EM.Transfer.DAL.Repository.UnitOfWorks;
using Microsoft.Practices.Unity;

namespace EM.Transfer.Web.Unity
{
    public static class UnityManager
    {
        private static IUnityContainer _container;

        public static T GetInstance<T>(params ResolverOverride[] overrides)
        {
            try
            {
                return _container.Resolve<T>(overrides);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return default(T);
            }
        }

        public static object GetInstance(Type t, params ResolverOverride[] overrides)
        {
            try
            {
                return _container.Resolve(t, overrides);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return null;
            }
        }

        public static void Register(HttpConfiguration config)
        {
            _container = new UnityContainer();

            //EF DATABASE
            //_container.RegisterType<IDbContextFactory<TransactionDbContext>, TransactionDbContextFactory>();
            //_container.RegisterType<DbContext, TransactionDbContext>(new InjectionFactory(c => TransactionDbContext.Create()));
            //_container.RegisterType<IRepositoryFactory, RepositoryFactory>();
            //_container.RegisterType<ITransactionProvider, TransactionProviderEF>();
            //_container.RegisterType<ITransactionRepository, TransactionRepositoryEF>();
            //_container.RegisterType<ITransactionUnitOfWork, TransactionUnitOfWorkEF>();

            // REST API
            _container.RegisterType<ITransactionRepository, TransactionRepositoryRest>();
            _container.RegisterType<ITransactionProvider, TransactionProviderRest>();
            _container.RegisterType<ITransactionUnitOfWork, TransactionUnitOfWorkRest>();
            _container.RegisterType<ITransactionManager, TransactionManager>();


            //AutoMapper
            _container.RegisterType<IMapper>(new ContainerControlledLifetimeManager(), new InjectionFactory(x => new MapperConfiguration(cfg =>
            {
                cfg.ConstructServicesUsing(serviceType => GetInstance(serviceType));
                cfg.CreateMap<Transaction, TransactionResponse>();
                cfg.CreateMap<Transaction, TransactionRequest>();

            }).CreateMapper()));

            config.DependencyResolver = new UnityDependencyResolver(_container);
        }
    }
}