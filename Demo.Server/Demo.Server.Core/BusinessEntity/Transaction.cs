using Demo.Server.Core.BusinessEntity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Server.Core.BusinessEntity
{
    public class Transaction
    {
        public long Id { get; set; }
        public int ClientId { get; set; }
        public long Amount { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Client Client { get; set; }

        public Transaction(long id, int clientId, long amount, TransactionCategory transactionCategory, DateTime createdDateTime, Client client)
        {
            Id = id;
            ClientId = clientId;
            Amount = amount;
            TransactionCategory = transactionCategory;
            CreatedDateTime = createdDateTime;
            Client = client;
        }
    }

    public static class TransactionExtension
    {
        public static long TotalRevenue(this List<Transaction> transactions)
        {
            return transactions.Where(c => c.TransactionCategory == TransactionCategory.Revenue).Sum(g => g.Amount);
        }

        public static long TotalServiceCost(this List<Transaction> transactions)
        {
            return transactions.Where(c => c.TransactionCategory == TransactionCategory.ServiceCost).Sum(g => g.Amount);
        }

        public static long TotalOtherOperationCost(this List<Transaction> transactions)
        {
            return transactions.Where(c => c.TransactionCategory == TransactionCategory.OtherOperationCost).Sum(g => g.Amount);
        }

        public static long TotalProfit(this List<Transaction> transactions)
        {
            return transactions.TotalRevenue() - transactions.TotalServiceCost() - transactions.TotalOtherOperationCost();
        }

        public static decimal TotalProfitMargin(this List<Transaction> transactions)
        {
            var totalRevenue = transactions.TotalRevenue();
            return totalRevenue == 0 ? 0 : (1.0M * transactions.TotalProfit() / totalRevenue);
        }
    }
}
