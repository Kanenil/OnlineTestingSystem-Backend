using MediatR;
using OnlineTestingSystem.Application.DTOs.Test;
using OnlineTestingSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class CreateTestCommand : IRequest<BaseCommandResponse>
{
    public TestCreateDTO TestDTO { get; set; }
}
