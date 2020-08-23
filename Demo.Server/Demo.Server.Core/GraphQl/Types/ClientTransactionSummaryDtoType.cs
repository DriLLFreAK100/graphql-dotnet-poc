using Demo.Server.Core.BusinessEntity.Dto;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class ClientTransactionSummaryDtoType: ObjectGraphType<ClientTransactionSummaryDto>
    {
        public ClientTransactionSummaryDtoType()
        {
            Field(x => x.Id).Description("Client's ID");
            Field(x => x.ClientName).Description("Client's Name");
            Field(x => x.TotalRevenue).Description("Total Revenue gained from serving the client");
            Field(x => x.TotalServiceCost).Description("Total Service Cost spent on the client");
            Field(x => x.TotalOtherOperationCost).Description("Total Operation Cost spent on the client");
            Field(x => x.TotalProfit).Description("Total clean profit gained from serving the client");
            Field(x => x.TotalProfitMargin).Description("Total profit margin");
        }
    }
}
