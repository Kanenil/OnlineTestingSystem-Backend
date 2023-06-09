﻿using MediatR;
using OnlineTestingSystem.Application.DTOs.Test;
using OnlineTestingSystem.Application.Responses;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class CreateTestCommand : IRequest<BaseCommandResponse>
{
    public TestCreateDTO TestDTO { get; set; }
}
