using Demo.Server.Core.BusinessEntity;
using System.Collections.Generic;

namespace Demo.Server.Core.Repository.Interface
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        Client GetClient(int id);
    }
}
