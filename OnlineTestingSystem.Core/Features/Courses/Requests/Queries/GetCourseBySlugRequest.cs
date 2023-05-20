using MediatR;
using OnlineTestingSystem.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Queries
{
    public class GetCourseBySlugRequest : IRequest<CourseDTO>
    {
        public string Slug { get; set; }
    }
}
