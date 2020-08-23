using Demo.Server.Core.BusinessEntity.Dto;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class TransactionSummaryByMonthType : ObjectGraphType<TransactionSummaryByMonthDto>
    {
        public TransactionSummaryByMonthType()
        {
            Field<MonthType>("Month", "Month of transaction in requested year", resolve: context => context.Source.Month);
            Field(x => x.TotalRevenue).Description("Total revenue of the month in requested year");
            Field(x => x.TotalServiceCost).Description("Total service cost of the month in requested year");
            Field(x => x.TotalOtherOperationCost).Description("Total operation cost of the month in requested year");
            Field(x => x.TotalProfit).Description("Total profit of the month in requested year");
        }
    }
}
