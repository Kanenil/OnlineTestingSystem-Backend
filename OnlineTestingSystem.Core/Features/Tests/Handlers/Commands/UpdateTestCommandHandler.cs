using AutoMapper;
using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using OnlineTestingSystem.Application.Responses;
using OnlineTestingSystem.Domain;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands;

public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
    {
        var test = await _unitOfWork.TestsRepository.GetAsync(request.TestDTO.Id);

        if (test is null)
            throw new NotFoundException(nameof(test), request.TestDTO.Id);

        _mapper.Map(request.TestDTO, test);

        await _unitOfWork.TestsRepository.UpdateAsync(test);
        await _unitOfWork.Save();

        return Unit.Value;
    }
}
