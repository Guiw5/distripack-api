using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client = DistripackAPI.Models.Client;

namespace DistripackAPI.Services.Impl
{
    public class TransactionService : Service, ITransactionService
    {
        public TransactionService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<TransactionService> logger) :
            base(mapper, unitOfWork, logger)
        { }

        public async Task<Transaction> RegisterPayment(CreatePayment payment)
        {
            Client client = null;

            if (payment.ClientId.HasValue)
                client = await unitOfWork.Clients.GetWithAccount(payment.ClientId.Value);

            if (client == null)
                return null; //notFound()


            if (client.CheckingAccount == null)
                throw new Exception($"the client: { payment.ClientId } doesn't have a checking account");

            var newPayment = Models.Transaction.CreatePayment(client.CheckingAccount.Id, payment);

            var entry = unitOfWork.Transactions.Add(newPayment);
            await unitOfWork.Complete();
            await entry.Reference(x => x.CheckingAccount).LoadAsync();
            return mapper.Map<Transaction>(entry.Entity);
        }

        public async Task<ICollection<Transaction>> GetTransactions(int clientId)
        {
            var transactions = await unitOfWork.Transactions.GetByClient(clientId);
            return mapper.Map<IList<Transaction>>(transactions);
        }

        public async Task<CheckingAccount> GetCheckingAccount(int clientId)
        {
            var account = await unitOfWork.CheckingAccounts.Find(c => c.ClientId == clientId);
            return mapper.Map<CheckingAccount>(account);
        }
    }
}