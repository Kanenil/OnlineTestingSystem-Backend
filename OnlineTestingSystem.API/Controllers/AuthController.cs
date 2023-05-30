using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.API.Middleware;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Application.Models.Identity;
using System.Security.Claims;

namespace OnlineTestingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    // POST api/<CoursesController>/login
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    // POST api/<CoursesController>/register
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }

    // POST api/<CoursesController>/google/login
    [HttpPost("google/login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<AuthResponse>> GoogleLogin(GoogleLogin model)
    {
        return Ok(await _authenticationService.GoogleLogin(model.GoogleToken));
    }

    // POST api/<CoursesController>/google/register
    [HttpPost("google/register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<AuthResponse>> GoogleRegister(GoogleRegister model)
    {
        return Ok(await _authenticationService.GoogleRegister(model));
    }

    // POST api/<CoursesController>/refresh-token
    [HttpPost("refresh-token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult> RefreshToken([FromBody] TokenModel model)
    {
        return Ok(await _authenticationService.RefreshToken(model));
    }

}
