using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.API.Middleware;
using OnlineTestingSystem.Application.DTOs.Test;
using OnlineTestingSystem.Application.Features.Courses.Requests.Commands;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using OnlineTestingSystem.Application.Responses;

namespace OnlineTestingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/<TestsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] TestCreateDTO model)
    {
        var command = new CreateTestCommand { TestDTO = model };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    // PUT api/<TestsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TestsController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTestCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
