using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands
{
    public class DeleteTestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
