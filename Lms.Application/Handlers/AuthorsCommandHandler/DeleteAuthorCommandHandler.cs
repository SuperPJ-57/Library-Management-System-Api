using Lms.Application.Commands.Authors;
using Lms.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.AuthorsCommandHandler
{
    public class DeleteAuthorCommandHandler:IRequestHandler<DeleteAuthorCommand,Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.DeleteAuthorAsync(request.AuthorId);
            return Unit.Value;
        }
    }
}
