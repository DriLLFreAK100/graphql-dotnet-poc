using Demo.Server.Core.BusinessEntity.Enum;
using GraphQL.Types;

namespace Demo.Server.Core.GraphQl.Types
{
    public class TransactionCategoryType: EnumerationGraphType<TransactionCategory>
    {
        public TransactionCategoryType()
        {
            Name = "TransactionCategory";
            AddValue("Revenue", "Total income generated", TransactionCategory.Revenue);
            AddValue("ServicingCost", "Cost incurred from servicing a client", TransactionCategory.ServiceCost);
            AddValue("OtherOperatingCost", "Other cost incurred during the business process", TransactionCategory.OtherOperationCost);
        }
    }
}
