using Demo.Server.Core.BusinessEntity.Enum;

namespace Demo.Server.Core.BusinessEntity.Dto
{
    public class TransactionSummaryByMonthDto
    {
        public Month Month { get; set; }
        public long TotalRevenue { get; set; }
        public long TotalServiceCost { get; set; }
        public long TotalOtherOperationCost { get; set; }
        public long TotalProfit
        {
            get
            {
                return TotalRevenue - TotalServiceCost - TotalOtherOperationCost;
            }
        }

        public TransactionSummaryByMonthDto(Month month, long totalRevenue, long totalServiceCost, long totalOtherOperationCost)
        {
            Month = month;
            TotalRevenue = totalRevenue;
            TotalServiceCost = totalServiceCost;
            TotalOtherOperationCost = totalOtherOperationCost;
        }
    }
}
