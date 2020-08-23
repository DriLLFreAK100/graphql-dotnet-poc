using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.BusinessEntity.Dto;
using Demo.Server.Core.BusinessEntity.Enum;
using Demo.Server.Core.Repository.Interface;
using Demo.Server.Core.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Server.Core.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;

        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }

        public List<Transaction> GetTransactions(int year)
        {
            // Apply Business Logics...
            return _repo.GetTransactions(year);
        }

        public List<Transaction> GetClientTransactions(int clientId, int year)
        {
            // Apply Business Logics...
            return _repo.GetClientTransactions(clientId, year);
        }

        public List<int> GetAvailableTransactionYears()
        {
            // Apply Business Logics...
            return _repo.GetAvailableTransactionYears()
                .OrderByDescending(y => y)
                .ToList();
        }

        public List<TransactionSummaryByMonthDto> GetTransactionSummaryByMonth(int year)
        {
            return _repo.GetTransactions(year)
                .GroupBy(t => t.CreatedDateTime.Month)
                .OrderBy(t => t.Key)
                .Select(t => new TransactionSummaryByMonthDto
                (
                    t.First().CreatedDateTime.GetMonth(),
                    t.Where(x => x.TransactionCategory == TransactionCategory.Revenue).Sum(x => x.Amount),
                    t.Where(x => x.TransactionCategory == TransactionCategory.ServiceCost).Sum(x => x.Amount),
                    t.Where(x => x.TransactionCategory == TransactionCategory.OtherOperationCost).Sum(x => x.Amount)
                ))
                .ToList();
        }
    }
}
