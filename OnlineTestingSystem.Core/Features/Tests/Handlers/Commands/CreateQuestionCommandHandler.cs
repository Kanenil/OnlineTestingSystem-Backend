using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using OnlineTestingSystem.Application.Responses;
using OnlineTestingSystem.Domain;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var question = _mapper.Map<QuestionEntity>(request.QuestionDTO);

        question = await _unitOfWork.TestsRepository.AddQuestionAsync(question);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = question.Id;

        return response;
    }
}
