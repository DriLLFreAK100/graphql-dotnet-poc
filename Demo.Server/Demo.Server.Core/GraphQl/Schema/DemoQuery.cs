using Demo.Server.Core.GraphQl.Types;
using Demo.Server.Core.Service.Interface;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Schema
{
    public class DemoQuery : ObjectGraphType<object>
    {
        public DemoQuery(ITransactionService transactionService, IClientService clientService)
        {
            Name = "Query";
            Field<ListGraphType<TransactionType>>(
                "transactions",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "year" }),
                resolve: context => transactionService.GetTransactions(context.GetArgument<int>("year")),
                description: "Get all transactions for the specified year"
            );
            Field<ListGraphType<ClientType>>(
                "clients",
                resolve: _ => clientService.GetClients(),
                description: "Get all available clients"
            );
            Field<ListGraphType<ClientType>>(
                "client",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context => clientService.GetClient(context.GetArgument<int>("id")),
                description: "Get client with specified ID"
            );
            Field<ListGraphType<ClientTransactionSummaryDtoType>>(
                "topPerformingClient",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count" }, new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "year" }),
                resolve: context => clientService.GetTopPerformingClients(context.GetArgument<int>("count"), context.GetArgument<int>("year")),
                description: "Get top performing clients. Max limit count = 5"
            );
            Field<ListGraphType<ClientTransactionSummaryDtoType>>(
                "worstPerformingClient",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "count" }, new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "year" }),
                resolve: context => clientService.GetWorstPerformingClients(context.GetArgument<int>("count"), context.GetArgument<int>("year")),
                description: "Get worst performing clients. Max limit count = 5"
            );
            Field<ListGraphType<IntGraphType>>(
                "availableTransactionYears",
                resolve: context => transactionService.GetAvailableTransactionYears(),
                description: "Get the list of years where transactions happened"
            );
            Field<ListGraphType<TransactionSummaryByMonthType>>(
                "transactionSummaryByMonth",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "year" }),
                resolve: context => transactionService.GetTransactionSummaryByMonth(context.GetArgument<int>("year")),
                description: "Get transaction summary for a year by month"
            );
        }
    }
}
