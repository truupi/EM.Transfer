using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Practices.Unity;
using Moq;

namespace EM.Transfer.DAL.UnitTests
{
    [ExcludeFromCodeCoverage]
    public abstract class TestBase<TTestInterface, TTestType>
            where TTestType : TTestInterface
    {
        protected IUnityContainer _container;
        protected MockRepository _mockRepository;

        protected TTestInterface Instance
        {
            get
            {
                try
                {
                    return _container.Resolve<TTestInterface>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        public virtual void TestInitialize()
        {
            if (_container == null)
                _container = new UnityContainer();

            if (!_container.IsRegistered<TTestInterface>())
                _container.RegisterType<TTestInterface, TTestType>();

            if (_mockRepository == null)
                _mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public virtual void TestCleanup()
        {
            try
            {
                _container.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                _container = null;
                _mockRepository = null;
            }
        }

        protected Mock<T> CreateMock<T>() where T : class
        {
            Mock<T> mock = _mockRepository.Create<T>();
            _container.RegisterInstance(mock.Object);
            return mock;
        }
    }
}

