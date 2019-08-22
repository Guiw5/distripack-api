using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface ITransactionService
    {
        Task<Transaction> RegisterPayment(CreatePayment payment);

        Task<ICollection<Transaction>> GetTransactions(int clientId);

        Task<CheckingAccount> GetCheckingAccount(int clientId);

        Task<CheckingAccount> SetCheckingAccount(int clientId, int amount);
    }
}