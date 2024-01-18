using Licenta.API.Services;
using Licenta.SDK.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public partial class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost] public async Task<ActionResult> Login(LoginReqDto req)
        {
            bool loggedIn = await _accountService.Login(req);
            if (loggedIn == false) return NotFound();
            else return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterReqDto req)
        {
            bool registeredIn = await _accountService.Register(req);
            if (registeredIn == false) return Forbid();
            else return Ok();
        }
    }
}
