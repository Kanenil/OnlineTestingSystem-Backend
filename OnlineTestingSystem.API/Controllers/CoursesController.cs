using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.API.Middleware;
using OnlineTestingSystem.Application.Constants;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Features.Courses.Requests.Commands;
using OnlineTestingSystem.Application.Features.Courses.Requests.Queries;
using OnlineTestingSystem.Application.Models.Course;
using OnlineTestingSystem.Application.Responses;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineTestingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CoursesController>/all
        [HttpGet("all")]
        [Authorize(Roles = Roles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CourseDTO>>> GetAll()
        {
            var courses = await _mediator.Send(new GetCoursesListRequest());
            return Ok(courses);
        }

        // GET: api/<CoursesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CourseSearchResult>> Get([FromQuery] CourseSearch model)
        {
            var result = await _mediator.Send(new GetPaginatedCoursesListRequest() { Search = model });
            return Ok(result);
        }

        // GET api/<CoursesController>/id
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
        public async Task<ActionResult<CourseDTO>> GetById(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdRequest() { Id = id});
            return Ok(course);
        }

        // GET api/<CoursesController>/slug
        [HttpGet("slug/{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
        public async Task<ActionResult<CourseDTO>> GetBySlug(string slug)
        {
            var course = await _mediator.Send(new GetCourseBySlugRequest() { Slug = slug });
            return Ok(course);
        }


        // POST api/<CoursesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CourseCreateDTO course)
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            var command = new CreateCourseCommand { CourseDTO = course, Username = username };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<CoursesController>/join
        [HttpPost("join/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Join(int id)
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            var command = new JoinCourseCommand { CourseId = id, Username = username };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // POST api/<CoursesController>/leave
        [HttpPost("leave/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDeatils))]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Leave(int id)
        {
            string username = User.FindFirstValue(ClaimTypes.Name);
            var command = new LeaveCourseCommand { CourseId = id, Username = username };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CoursesController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] UpdateCourseDTO course)
        {
            var command = new UpdateCourseCommand { CourseDTO = course };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDeatils))]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
