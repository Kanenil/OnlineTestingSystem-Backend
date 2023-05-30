using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.API.Middleware;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Features.Users.Requests.Queries;

namespace OnlineTestingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    // GET api/<UsersController>/id
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<UserDTO>> GetById(int id)
    {
        var user = await _mediator.Send(new GetUserByIdRequest() { Id = id });
        return Ok(user);
    }

    // GET api/<UsersController>/slug
    [HttpGet("slug/{slug}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<UserDTO>> GetBySlug(string slug)
    {
        var user = await _mediator.Send(new GetUserBySlugRequest() { Slug = slug });
        return Ok(user);
    }

}
