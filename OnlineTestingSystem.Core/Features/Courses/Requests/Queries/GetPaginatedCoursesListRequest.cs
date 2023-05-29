using MediatR;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Queries
{
    public class GetPaginatedCoursesListRequest : IRequest<CourseSearchResult>
    {
        public CourseSearch Search { get; set; }
    }
}
