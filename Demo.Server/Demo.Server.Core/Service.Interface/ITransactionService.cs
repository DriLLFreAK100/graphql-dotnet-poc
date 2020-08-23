using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.BusinessEntity.Dto;
using System.Collections.Generic;

namespace Demo.Server.Core.Service.Interface
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions(int year);
        List<Transaction> GetClientTransactions(int clientId, int year);
        List<int> GetAvailableTransactionYears();
        List<TransactionSummaryByMonthDto> GetTransactionSummaryByMonth(int year);
    }
}
