using Demo.Server.Core.BusinessEntity;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class ClientType : ObjectGraphType<Client>
    {
        public ClientType()
        {
            Field(x => x.Id).Description("Client ID");
            Field(x => x.ClientName).Description("Client's Name");
            Field(x => x.Email).Description("Client's Email");
            Field(x => x.Address).Description("Client's Address");
            Field(x => x.IsPremium).Description("Indicates whether the client is Premium status");
            Field(x => x.EstablishedDate).Description("Client's Established Date");
        }
    }
}
