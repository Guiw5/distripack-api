using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
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
            var account = await unitOfWork.CheckingAccounts.Find(c => c.ClientId == clientId);
            return mapper.Map<CheckingAccount>(account);
        }

        public Task<CheckingAccount> SetCheckingAccount(int clientId, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}