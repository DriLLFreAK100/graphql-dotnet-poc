using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using Demo.Server.Core.BusinessEntity.Enum;
using System.Linq;

namespace Demo.Server.Core.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactionMocks;

        public TransactionRepository()
        {
            #region Init Mock Transactions
            TransactionCategory[] transactionTypes = new TransactionCategory[] { TransactionCategory.Revenue, TransactionCategory.ServiceCost, TransactionCategory.OtherOperationCost };
            Random random = new Random();
            ClientRepository clientRepo = new ClientRepository();

            _transactionMocks = new List<Transaction>();
            Enumerable.Range(1, 10000).ToList().ForEach(id => 
            {
                var clientId = random.Next(1, 12);
                _transactionMocks.Add(new Transaction
                (
                    id,
                    clientId,
                    random.Next(1000, 100000),
                    (TransactionCategory)transactionTypes[random.Next(0, 3)],
                    new DateTime(random.Next(1975, 2021), random.Next(1, 13), random.Next(1, 28)),
                    clientRepo.GetClient(clientId)
                ));
            });
            #endregion
        }

        public List<Transaction> GetTransactions(int year)
        {
            return _transactionMocks.Where(t => t.CreatedDateTime.Year == year).ToList();
        }

        public List<Transaction> GetClientTransactions(int clientId, int year)
        {
            return _transactionMocks.Where(t => t.ClientId == clientId && t.CreatedDateTime.Year == year).ToList();
        }

        public List<int> GetAvailableTransactionYears()
        {
            return _transactionMocks.Select(t => t.CreatedDateTime.Year).Distinct().ToList();
        }
    }
}
