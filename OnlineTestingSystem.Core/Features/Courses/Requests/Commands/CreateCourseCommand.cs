using MediatR;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Commands
{
    public class CreateCourseCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDTO CourseDTO { get; set; }
    }
}
