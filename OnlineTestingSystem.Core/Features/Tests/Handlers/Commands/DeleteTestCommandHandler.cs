using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands;

public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTestCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTestCommand request, CancellationToken cancellationToken)
    {
        var test = await _unitOfWork.TestsRepository.GetAsync(request.Id);

        if (test == null)
            throw new NotFoundException(nameof(test), request.Id);

        await _unitOfWork.TestsRepository.DeleteAsync(test);
        await _unitOfWork.Save();
    }
}
