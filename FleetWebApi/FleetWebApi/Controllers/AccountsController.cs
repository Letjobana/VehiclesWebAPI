using FleetWebApi.Models;
using FleetWebApi.Repositories.Abstract;
using FleetWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FleetWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountsController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpPost("MakeDeposite")]
        public async Task<ActionResult<Account>> MakeDeposite([FromBody] AccountViewModel account)
        {
            try
            {
                if (account == null)
                    return BadRequest();
                var deposit = await accountRepository.Deposite(account);
                return deposit;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error making new deposite");
            }
        }
    }
}
