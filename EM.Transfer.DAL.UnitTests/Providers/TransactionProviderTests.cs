using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EM.Transfer.DAL.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EM.Transfer.DAL.UnitTests.Providers
{
    [TestClass]
    public class TransactionProviderTests : TransactionProviderTestCommon
    {
        [TestInitialize]
        public override void TestInitialize() => base.TestInitialize();

        [TestCleanup]
        public override void TestCleanup() => base.TestCleanup();

        [TestMethod]
        public async Task TransactionProvider_GetAllAsync_Success_CorrectList()
        {
            _mockTransactionRepository.Setup
                (x => x.ReadAsync(
                    It.IsAny<Expression<Func<Transaction, bool>>>(),
                    It.IsAny<Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>>>(),
                    It.IsAny<Expression<Func<Transaction, object>>[]>())
                ).ReturnsAsync(TransactionList1);
            _mockTransactionRepository.Setup(x => x.Dispose());

            var testResult = await Instance.GetAllAsync();

            _mockTransactionRepository.Verify(x => x.ReadAsync(It.IsAny<Expression<Func<Transaction, bool>>>(),
                It.IsAny<Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>>>(),
                It.IsAny<Expression<Func<Transaction, object>>[]>()), Times.Once);

            CollectionAssert.AreEqual(TransactionList1.ToList(), testResult.ToList());
        }
    }
}
