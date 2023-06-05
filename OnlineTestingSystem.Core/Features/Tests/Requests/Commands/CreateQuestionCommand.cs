using MediatR;
using OnlineTestingSystem.Application.DTOs.Question;
using OnlineTestingSystem.Application.Responses;

namespace OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

public class CreateQuestionCommand : IRequest<BaseCommandResponse>
{
    public QuestionCreateDTO QuestionDTO { get; set; }
}
