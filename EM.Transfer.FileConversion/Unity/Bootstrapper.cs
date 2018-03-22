using System;
using AutoMapper;
using EM.Transfer.BL.Common.Models;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Provider.Providers;
using EM.Transfer.DAL.Repository.Repositories;
using EM.Transfer.DAL.Repository.UnitOfWorks;
using EM.Transfer.FileConversion.Factories;
using EM.Transfer.FileConversion.FileHandlers;
using EM.Transfer.FileConversion.FileOperations;
using EM.Transfer.FileConversion.Managers;
using EM.Transfer.FileConversion.Watchers;
using Microsoft.Practices.Unity;
using ITransactionManager = EM.Transfer.FileConversion.Managers.ITransactionManager;

namespace EM.Transfer.FileConversion.Unity
{
    public static class Bootstrapper
    {
        public static void SetupContainer(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            // AUTOMAPPER
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Transaction, TransactionResponse>();
                cfg.CreateMap<Transaction, TransactionRequest>();
            });

            var mapper = config.CreateMapper();

            container.RegisterInstance(mapper);
            container.RegisterType<IMapper>(new ContainerControlledLifetimeManager(),
                new InjectionFactory(x => mapper));


            // FILE CONVERSION
            container.RegisterType<IFileConvertFactory<TransactionRequest>, TransactionConvertFactory>();
            container.RegisterType<IFileOperations, CsvFileOperations>();
            container.RegisterType<IFileSystemWatcher, FileSystemWatcherWrapper>(new InjectionConstructor());
            container.RegisterType<IWatcher, CsvFileWatcher>();
            container.RegisterType<ITransactionManager, TransactionManager>();

            // DAL & BL
            container.RegisterType<ITransactionRepository, TransactionRepositoryRest>(new InjectionConstructor());
            container.RegisterType<ITransactionProvider, TransactionProviderRest>();
            container.RegisterType<ITransactionUnitOfWork, TransactionUnitOfWorkRest>();
            container.RegisterType<DAL.Common.Interfaces.ITransactionManager, BL.Transfering.TransactionManager>();
        }
    }
}
