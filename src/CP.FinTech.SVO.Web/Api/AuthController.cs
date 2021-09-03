using CP.FinTech.SVO.Infrastructure.Ethereum.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CP.FinTech.SVO.Infrastructure.Ethereum.Interfaces;

namespace CP.FinTech.SVO.Web.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IAccountService _accountService;
        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<AccountDAO> Authenticate(AccountDAO account)
        {
            var found = _accountService.Authenticate(account.Address, account.Password);
            if (found == null)
                return BadRequest();
            return Ok(found);
        }

    }
}