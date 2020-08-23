using Demo.Server.Core.BusinessEntity;
using Demo.Server.Core.Service.Interface;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class TransactionType: ObjectGraphType<Transaction>
    {
        public TransactionType(IClientService clientService)
        {
            Field(x => x.Id).Description("Id of the transaction");
            Field(x => x.Amount).Description("Amount of the transaction");
            Field<TransactionCategoryType>("TransactionCategory", resolve: context => context.Source.TransactionCategory, description: "Transaction Category, i.e. Revenue, Cost, etc.");
            Field(x => x.CreatedDateTime).Description("Transaction Date and Time recorded");
            Field<ClientType>("client", resolve: context => clientService.GetClient(context.Source.ClientId), description: "Client associated with the Transaction.");
        }
    }
}
