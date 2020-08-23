using Demo.Server.Core.BusinessEntity;
using System.Collections.Generic;

namespace Demo.Server.Core.Repository.Interface
{
    public interface ITransactionRepository
    {
        List<Transaction> GetTransactions(int year);
        List<Transaction> GetClientTransactions(int clientId, int year);
        List<int> GetAvailableTransactionYears();
    }
}
