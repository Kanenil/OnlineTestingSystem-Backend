using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands;

public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnswerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        var answer = await _unitOfWork.TestsRepository.GetAnswerAsync(request.Id);

        if (answer == null)
            throw new NotFoundException(nameof(answer), request.Id);

        await _unitOfWork.TestsRepository.DeleteAnswerAsync(answer);
        await _unitOfWork.Save();
    }
}
