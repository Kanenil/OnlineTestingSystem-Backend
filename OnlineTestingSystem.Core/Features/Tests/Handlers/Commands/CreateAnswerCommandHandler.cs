using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using OnlineTestingSystem.Application.Responses;
using OnlineTestingSystem.Domain;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAnswerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var answer = _mapper.Map<AnswerEntity>(request.AnswerDTO);

        answer = await _unitOfWork.TestsRepository.AddAnswerAsync(answer);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = answer.Id;

        return response;
    }
}
