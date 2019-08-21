using DistripackAPI.Controllers.ApiModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Models
{
    public class CheckingAccount : Entity
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

        public int ClientId { get; private set; }
        public Client Client { get; private set; }
        public double CurrentBalance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Receipt AddReceipt(Order order)
        {
            var receipt = new Receipt(Id, order.Id, order.Subtotal);
            CurrentBalance += receipt.Amount;
            Transactions.Add(receipt);
            return receipt;
        }

        public Payment AddPayment(CreatePayment apiPayment)
        {
            var payment = new Payment(Id, apiPayment.Method, apiPayment.PaymentAt, apiPayment.Amount.Value);
            CurrentBalance -= payment.Amount;
            Transactions.Add(payment);
            return payment;
        }
    }
}