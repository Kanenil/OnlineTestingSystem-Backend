using MediatR;
using OnlineTestingSystem.Application.DTOs.Test;
using OnlineTestingSystem.Application.Responses;


namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class UpdateTestCommand : IRequest<Unit>
{
    public TestUpdateDTO TestDTO { get; set; }
}
