using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.BusinessEntity.Dto;
using System.Collections.Generic;

namespace Demo.Server.Core.Service.Interface
{
    public interface IClientService
    {
        List<Client> GetClients();
        Client GetClient(int id);
        List<ClientTransactionSummaryDto> GetTopPerformingClients(int count, int year);
        List<ClientTransactionSummaryDto> GetWorstPerformingClients(int count, int year); 
    }
}
