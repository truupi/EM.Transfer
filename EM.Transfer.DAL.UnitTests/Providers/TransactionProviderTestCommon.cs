using System.Collections.Generic;
using EM.Transfer.DAL.Common.Entities;
using EM.Transfer.DAL.Common.Interfaces;
using EM.Transfer.DAL.Provider.Providers;
using Moq;

namespace EM.Transfer.DAL.UnitTests.Providers
{
    public class TransactionProviderTestCommon : TestBase<ITransactionProvider, TransactionProviderRest>
    {
        internal Mock<ITransactionRepository> _mockTransactionRepository;

        #region transaction1
        internal static readonly string SourceAccountNumber1 = "00000000-11111111-22222222";
        internal static readonly string TargetAccountNumber1 = "22222222-11111111-00000000";
        internal static readonly int MoneyAmount1 = 30000;
        internal static readonly Transaction Transaction1 = new Transaction
        {
            Id = 1,
            SourceAccountNumber = SourceAccountNumber1,
            TargetAccountNumber = TargetAccountNumber1,
            MoneyAmount = MoneyAmount1
        };
        #endregion

        #region transaction2
        internal static readonly string SourceAccountNumber2 = "22222222-11111111-00000000";
        internal static readonly string TargetAccountNumber2 = "00000000-11111111-22222222";
        internal static readonly int MoneyAmount2 = 10000;
        internal static readonly Transaction Transaction2 = new Transaction
        {
            Id = 2,
            SourceAccountNumber = SourceAccountNumber2,
            TargetAccountNumber = TargetAccountNumber2,
            MoneyAmount = MoneyAmount2
        };
        #endregion

        #region transactionList1
        internal static readonly IEnumerable<Transaction> TransactionList1 = new List<Transaction>
        {
            Transaction1
        };
        #endregion

        #region transactionList2
        internal static readonly IEnumerable<Transaction> TransactionList2 = new List<Transaction>
        {
            Transaction2
        };
        #endregion

        public override void TestInitialize()
        {
            base.TestInitialize();

            _mockTransactionRepository = CreateMock<ITransactionRepository>();
        }
    }
}
