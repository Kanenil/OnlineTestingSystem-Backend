using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Models.Account;
using System.Security.Claims;

namespace OnlineTestingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            string name = User.FindFirstValue(ClaimTypes.Name);
            return Ok(await _accountService.Profile(name));
        }

        [HttpPost("edit")]
        public async Task<ActionResult<UserDTO>> Edit(EditProfile model)
        {
            string name = User.FindFirstValue(ClaimTypes.Name);
            await _accountService.EditProfile(name, model);
            return NoContent();
        }


        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            string name = User.FindFirstValue(ClaimTypes.Name);
            await _accountService.Logout(name);
            return NoContent();
        }
    }
}
