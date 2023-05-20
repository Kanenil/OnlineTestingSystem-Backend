﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Features.Courses.Requests.Commands;
using OnlineTestingSystem.Application.Features.Courses.Requests.Queries;
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

        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> Get()
        {
            var courses = await _mediator.Send(new GetCoursesListRequest());
            return Ok(courses);
        }

        // GET api/<CoursesController>/id
        [HttpGet("id/{id}")]
        public async Task<ActionResult<CourseDTO>> GetById(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdRequest() { Id = id});
            return Ok(course);
        }

        // GET api/<CoursesController>/slug
        [HttpGet("slug/{slug}")]
        public async Task<ActionResult<CourseDTO>> GetBySlug(string slug)
        {
            var course = await _mediator.Send(new GetCourseBySlugRequest() { Slug = slug });
            return Ok(course);
        }


        // POST api/<CoursesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CourseCreateDTO course)
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var command = new CreateCourseCommand { CourseDTO = course, Email = email };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<CoursesController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> Put([FromBody] CourseDTO course)
        {
            var command = new UpdateCourseCommand { CourseDTO = course };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
