using Lms.Application.Commands.BookInstances;
using Lms.Application.Interfaces;
using Lms.Domain.Models;
using MediatR;

namespace Lms.Application.Handlers.BookInstancesCommandHandler
{
    public class DeleteBookInstanceCommandHandler:IRequestHandler<DeleteBookInstanceCommand, DeleteOperationResult>
    {
        private readonly IBookInstanceService _bookInstanceService;
        public DeleteBookInstanceCommandHandler(IBookInstanceService bookInstanceService)
        {
            _bookInstanceService = bookInstanceService;
        }
        public async Task<DeleteOperationResult> Handle(DeleteBookInstanceCommand request, CancellationToken cancellationToken)
        {
            return await _bookInstanceService.DeleteBookInstanceAsync(request.BarCode);

        }
    }
}
