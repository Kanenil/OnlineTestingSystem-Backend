using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Features.Users.Requests.Queries;

namespace OnlineTestingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _mediator.Send(new GetUserRequest() { Id = id });
            return Ok(user);
        }

    }
}
