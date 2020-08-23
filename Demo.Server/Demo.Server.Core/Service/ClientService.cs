using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.BusinessEntity.Dto;
using Demo.Server.Core.Repository.Interface;
using Demo.Server.Core.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Server.Core.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepo;
        private readonly ITransactionRepository _transactionRepo;

        public ClientService(IClientRepository clientRepo, ITransactionRepository transactionRepo)
        {
            _clientRepo = clientRepo;
            _transactionRepo = transactionRepo;
        }

        public Client GetClient(int id)
        {
            // Apply Business Logics...
            return _clientRepo.GetClient(id);
        }

        public List<Client> GetClients()
        {
            // Apply Business Logics...
            return _clientRepo.GetClients();
        }

        public List<ClientTransactionSummaryDto> GetTopPerformingClients(int count, int year)
        {
            // Apply Business Logics...
            return _transactionRepo
                .GetTransactions(year)
                .GroupBy(t => t.ClientId)
                .OrderByDescending(t => t.Sum(g => g.Amount))
                .Take(count > 10 ? 10 : count)
                .Select(x => new ClientTransactionSummaryDto
                (
                    x.Key,
                    x.First().Client.ClientName,
                    x.ToList().TotalRevenue(),
                    x.ToList().TotalServiceCost(),
                    x.ToList().TotalOtherOperationCost()
                ))
                .ToList();
        }

        public List<ClientTransactionSummaryDto> GetWorstPerformingClients(int count, int year)
        {
            // Apply Business Logics...
            return _transactionRepo
                .GetTransactions(year)
                .GroupBy(t => t.ClientId)
                .OrderBy(t => t.Sum(g => g.Amount))
                .Take(count > 10 ? 10 : count)
                .Select(x => new ClientTransactionSummaryDto
                (
                    x.Key,
                    x.First().Client.ClientName,
                    x.ToList().TotalRevenue(),
                    x.ToList().TotalServiceCost(),
                    x.ToList().TotalOtherOperationCost()
                ))
                .ToList();
        }
    }
}
