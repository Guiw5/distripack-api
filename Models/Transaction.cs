using System;
using System.Diagnostics.CodeAnalysis;

namespace DistripackAPI.Models
{
    public enum TransactionType
    {
        Payment,
        Receipt
    }

    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
    public abstract class Transaction
    {
        protected Transaction(TransactionType type)
        {
            Type = type.ToString();
            CreatedAt = DateTime.Now;
        }

        protected Transaction(int checkingAccountId, TransactionType type, double amount) : this(type)
        {
            Amount = amount;
            CheckingAccountId = checkingAccountId;
        }
        public int Id { get; set; }
        public int CheckingAccountId { get; private set; }
        public CheckingAccount CheckingAccount { get; private set; }
        public double Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Type { get; private set; }
        public double CurrentBalance { get; set; }
    }
}
