using System;

namespace DistripackAPI.Models
{
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
}