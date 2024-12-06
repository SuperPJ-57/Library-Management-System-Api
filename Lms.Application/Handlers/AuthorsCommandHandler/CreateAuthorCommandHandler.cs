using Lms.Application.Commands.Authors;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.AuthorsCommandHandler
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand,AuthorsEntity>
    {
        private readonly IAuthorService _authorService;
        public CreateAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<AuthorsEntity> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorsEntity
            {
                //AuthorId = request.AuthorId,
                Name = request.Name,
                Bio = request.Bio
            };
            return await _authorService.AddAuthorAsync(author);
        }
    }
}
