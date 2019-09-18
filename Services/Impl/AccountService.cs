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
    public class AccountService : Service, IAccountService
    {
        public AccountService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<AccountService> logger) :
            base(mapper, unitOfWork, logger)
        { }

        public async Task<Transaction> RegisterPayment(CreatePayment payment)
        {
            Client client = null;

            if (payment.ClientId.HasValue)
                client = await unitOfWork.Clients.GetWithAccount(payment.ClientId.Value);

            if (client == null)
                return null; //notFound()

            var paymentDb = client.AddPayment(payment);
            await unitOfWork.Complete();
            return mapper.Map<Transaction>(paymentDb);
        }

        public async Task<ICollection<Transaction>> GetTransactions(int clientId)
        {
            var transactions = await unitOfWork.Transactions.GetByClient(clientId);
            return mapper.Map<IList<Transaction>>(transactions);
        }

        public async Task<CheckingAccount> GetCheckingAccount(int clientId)
        {
            var account = await unitOfWork.CheckingAccounts.Get(clientId);
            return mapper.Map<CheckingAccount>(account);
        }

        public async Task<CheckingAccount> SetCheckingAccount(int clientId, int amount)
        {
            var client = await unitOfWork.Clients.GetWithAccount(clientId);

            if (client == null)
                throw new Exception($"El cliente '{clientId}' no existe");

            var account = client.AddAccount(amount);
            await unitOfWork.Complete();
            return mapper.Map<CheckingAccount>(account);

        }


        public async Task<CheckingAccount> SetInitialAmount(int clientId, int amount)
        {
            var client = await unitOfWork.Clients.GetWithAccount(clientId);

            if (client == null)
                throw new Exception($"El cliente '{clientId}' no existe");

            client.SetInitialAmount(amount);
            await unitOfWork.Complete();
            return mapper.Map<CheckingAccount>(client.CheckingAccount);

        }



        public async Task<ICollection<CheckingAccount>> GetAccounts()
        {
            var accounts = await unitOfWork.CheckingAccounts.GetAll();
            return mapper.Map<IList<CheckingAccount>>(accounts);
        }

    }
}