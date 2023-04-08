using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Courses.Requests.Commands
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
