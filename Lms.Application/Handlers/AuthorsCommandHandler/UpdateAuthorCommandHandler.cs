using Lms.Application.Commands.Authors;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.AuthorsCommandHandler
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorsEntity>
    {
        private readonly IAuthorService _authorService;
        public UpdateAuthorCommandHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<AuthorsEntity> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorsEntity
            {
                AuthorId = request.AuthorId,
                Name = request.Name,
                Bio = request.Bio
            };
            return await _authorService.UpdateAuthorAsync(author);
            
        }
    }
}
