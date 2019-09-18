using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> GetCheckingAccount(int clientId)
        {
            var account = await accountService.GetCheckingAccount(clientId);
            if (account == null)
                return NotFound($"El cliente {clientId} no existe o no tiene una cuenta asociada");

            return Ok(account);
        }

        [HttpPost]
        [Route("{clientId}")]
        public async Task<IActionResult> SetCheckingAccount(int clientId, [FromBody] int amount)
        {
            var account = await accountService.SetCheckingAccount(clientId, amount);
            return Ok(account);
        }

        [HttpPut]
        [Route("{clientId}")]
        public async Task<IActionResult> SetInitialAmount(int clientId, [FromBody] int amount)
        {
            var account = await accountService.SetInitialAmount(clientId, amount);
            return Ok(account);
        }

    }
}