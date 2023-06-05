using MediatR;
using OnlineTestingSystem.Application.DTOs.Answer;
using OnlineTestingSystem.Application.Responses;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class CreateAnswerCommand : IRequest<BaseCommandResponse>
{
    public AnswerCreateDTO AnswerDTO { get; set; }
}
