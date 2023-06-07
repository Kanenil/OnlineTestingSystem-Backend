using MediatR;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Features.Tests.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Application.Features.Tests.Handlers.Commands
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQuestionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await _unitOfWork.TestsRepository.GetQuestionAsync(request.Id);

            if (question == null)
                throw new NotFoundException(nameof(question), request.Id);

            await _unitOfWork.TestsRepository.DeleteQuestionAsync(question);
            await _unitOfWork.Save();
        }
    }
}
