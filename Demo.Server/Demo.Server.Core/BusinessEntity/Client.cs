using System;

namespace Demo.Server.Core.BusinessEntity
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsPremium { get; set; }
        public DateTime EstablishedDate { get; set; }

        public Client(int id, string clientName, string email, string address, bool isPremium, DateTime establishedDate)
        {
            Id = id;
            ClientName = clientName;
            Email = email;
            Address = address;
            IsPremium = isPremium;
            EstablishedDate = establishedDate;
        }
    }
}
