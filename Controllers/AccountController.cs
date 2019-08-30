using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IClientService clientService;

        public AccountController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await clientService.GetAccounts();
            return Ok(accounts);
        }
    }
}