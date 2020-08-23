using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Server.Core.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> _clientMocks;

        public ClientRepository()
        {
            _clientMocks = new List<Client>()
            {
                new Client(1, "Client A", "client.a@domain.com", "123, Client A, Street A", true, new DateTime(1975, 1, 1)),
                new Client(2, "Client B", "client.b@domain.com", "456, Client B, Street B", true, new DateTime(1975, 1, 1)),
                new Client(3, "Client C", "client.c@domain.com", "789, Client C, Street C", true, new DateTime(1975, 1, 1)),
                new Client(4, "Client D", "client.d@domain.com", "789, Client D, Street D", true, new DateTime(1975, 1, 1)),
                new Client(5, "Client E", "client.e@domain.com", "789, Client E, Street E", true, new DateTime(1975, 1, 1)),
                new Client(6, "Client F", "client.f@domain.com", "789, Client F, Street F", true, new DateTime(1975, 1, 1)),
                new Client(7, "Client G", "client.g@domain.com", "789, Client G, Street G", true, new DateTime(1975, 1, 1)),
                new Client(8, "Client H", "client.h@domain.com", "789, Client H, Street H", true, new DateTime(1975, 1, 1)),
                new Client(9, "Client I", "client.i@domain.com", "789, Client I, Street I", true, new DateTime(1975, 1, 1)),
                new Client(10, "Client J", "client.j@domain.com", "789, Client J, Street J", true, new DateTime(1975, 1, 1)),
                new Client(11, "Client K", "client.k@domain.com", "789, Client K, Street K", true, new DateTime(1975, 1, 1)),
            };
        }

        public Client GetClient(int id)
        {
            return _clientMocks.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetClients()
        {
            return _clientMocks.ToList();
        }
    }
}
