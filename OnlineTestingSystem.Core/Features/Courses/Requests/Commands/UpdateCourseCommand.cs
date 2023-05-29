using MediatR;
using OnlineTestingSystem.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Commands
{
    public class UpdateCourseCommand : IRequest<Unit>
    {
        public UpdateCourseDTO CourseDTO { get; set; }
    }
}
