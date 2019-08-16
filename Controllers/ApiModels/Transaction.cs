using System;
using System.Collections.Generic;

namespace DistripackAPI.Controllers.ApiModels
{
    public class AccountTransactions
    {
        public int ClientId { get; set; }
        public int AccountId { get; set; }
        public int CurrentBalance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    //todo is actually using same class for payments and receipts
    public class Transaction
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int AccountId { get; set; }
        public int CurrentBalance { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
        public int? OrderId { get; set; }
        public string Method { get; set; }
        public DateTime? PaymentAt { get; set; }
    }
}