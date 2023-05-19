using MediatR;
using OnlineTestingSystem.Application.DTOs.Course;
using OnlineTestingSystem.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Users.Requests.Queries
{
    public class GetUserRequest : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}
