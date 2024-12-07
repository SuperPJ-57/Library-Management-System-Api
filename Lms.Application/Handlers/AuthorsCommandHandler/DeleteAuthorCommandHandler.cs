using Lms.Application.Commands.Authors;
using Lms.Domain.Models;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.AuthorsCommandHandler
{
    public class DeleteAuthorCommandHandler:IRequestHandler<DeleteAuthorCommand,DeleteOperationResult>
    {
        private readonly IAuthorService _authorService;
        public DeleteAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<DeleteOperationResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            return await _authorService.DeleteAuthorAsync(request.AuthorId);
            
        }
    }
}
