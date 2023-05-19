﻿using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Application.Models.Identity;

namespace OnlineTestingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AccountController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }

        [HttpPost("google/login")]
        public async Task<ActionResult<AuthResponse>> GoogleLogin(GoogleLogin model)
        {
            return Ok(await _authenticationService.GoogleLogin(model.GoogleToken));
        }

        [HttpPost("google/register")]
        public async Task<ActionResult<AuthResponse>> GoogleRegister(GoogleRegister model)
        {
            return Ok(await _authenticationService.GoogleRegister(model));
        }

    }
}
