using MediatR;
using OnlineTestingSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Commands
{
    public class JoinCourseCommand : IRequest<BaseCommandResponse>
    {
        public string Username { get; set; }
        public int CourseId { get; set; }
    }
}
