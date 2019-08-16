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
    }
}