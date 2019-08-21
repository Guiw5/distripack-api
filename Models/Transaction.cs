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
    public abstract class Transaction : Entity
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

        public int CheckingAccountId { get; private set; }
        public CheckingAccount CheckingAccount { get; private set; }
        public double Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Type { get; private set; }
    }

    public class Payment : Transaction
    {
        public Payment(int checkingAccountId, PaymentMethod method, DateTime paymentAt, double amount)
            : base(checkingAccountId, TransactionType.Payment, amount)
        {
            Method = method;
            PaymentAt = paymentAt;

        }

        public PaymentMethod Method { get; private set; }
        public DateTime PaymentAt { get; private set; }

    }

    public class Receipt : Transaction
    {
        public Receipt() : base(TransactionType.Receipt) { }

        public Receipt(int checkingAccountId, int orderId, double amount)
            : base(checkingAccountId, TransactionType.Receipt, amount)
        {
            OrderId = orderId;
        }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }
    }
}
