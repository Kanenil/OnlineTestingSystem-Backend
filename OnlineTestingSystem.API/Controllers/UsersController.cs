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


        // GET api/<UsersController>/id
        [HttpGet("id/{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdRequest() { Id = id });
            return Ok(user);
        }

        // GET api/<UsersController>/slug
        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<UserDTO>> GetBySlug(string slug)
        {
            var user = await _mediator.Send(new GetUserBySlugRequest() { Slug = slug });
            return Ok(user);
        }

    }
}
