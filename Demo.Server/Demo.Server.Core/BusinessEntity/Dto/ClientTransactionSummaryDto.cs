namespace Demo.Server.Core.BusinessEntity.Dto
{
    public class ClientTransactionSummaryDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
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
        public decimal TotalProfitMargin 
        {
            get
            {
                return TotalRevenue == 0 ? 0 : (1.0M * TotalProfit/ TotalRevenue);
            }
        }

        public ClientTransactionSummaryDto(int id, string clientName, long totalRevenue, long totalServiceCost, long totalOtherOperationCost)
        {
            Id = id;
            ClientName = clientName;
            TotalRevenue = totalRevenue;
            TotalServiceCost = totalServiceCost;
            TotalOtherOperationCost = totalOtherOperationCost;
        }
    }
}
