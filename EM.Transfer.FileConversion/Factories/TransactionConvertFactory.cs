using System;
using EM.Transfer.BL.Common.Models;

namespace EM.Transfer.FileConversion.Factories
{
    public class TransactionConvertFactory : IFileConvertFactory<TransactionRequest>
    {
        public TransactionRequest Create(string[] transaction)
        {
            return new TransactionRequest
            {
                SourceAccountNumber = transaction[0],
                TargetAccountNumber = transaction[1],
                MoneyAmount = Convert.ToInt32(transaction[2])
            };
        }
    }
}
