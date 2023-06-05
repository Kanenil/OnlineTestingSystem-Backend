using MediatR;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class DeleteTestCommand : IRequest
{
    public int Id { get; set; }
}
