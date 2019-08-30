using DistripackAPI.Controllers.ApiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Models
{
    public class CheckingAccount
    {
        public CheckingAccount()
        {
            UpdatedAt = CreatedAt = DateTime.Now;
            Transactions = new Collection<Transaction>();
        }

        public CheckingAccount(int clientId, double currentBalance) : this()
        {
            ClientId = clientId;
            CurrentBalance = currentBalance;
        }

        public int Id { get; set; }
        public int ClientId { get; private set; }
        public Client Client { get; private set; }
        public double CurrentBalance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Receipt AddReceipt(Order order)
        {
            var receipt = new Receipt(Id, order.Id, order.Subtotal);
            AddTransaction(receipt);
            return receipt;
        }

        public Payment AddPayment(CreatePayment apiPayment)
        {
            if (!apiPayment.Amount.HasValue)
                throw new Exception($"El pago del cliente '{ClientId}' debe contener un monto");

            var signedAmount = -Math.Abs(apiPayment.Amount.Value);
            var payment = new Payment(Id, apiPayment.Method, apiPayment.PaymentAt, signedAmount);
            AddTransaction(payment);
            return payment;
        }

        private void AddTransaction(Transaction transaction)
        {
            CurrentBalance += transaction.Amount;
            transaction.CurrentBalance = CurrentBalance;
            Transactions.Add(transaction);
        }
    }
}