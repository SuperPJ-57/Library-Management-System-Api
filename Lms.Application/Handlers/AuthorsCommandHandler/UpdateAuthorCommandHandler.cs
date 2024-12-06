using Lms.Application.Commands.Authors;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.AuthorsCommandHandler
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorsEntity>
    {
        private readonly IAuthorRepository _authorRepository;
        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<AuthorsEntity> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new AuthorsEntity
            {
                AuthorId = request.AuthorId,
                Name = request.Name,
                Bio = request.Bio
            };
            return await _authorRepository.UpdateAuthorAsync(author);
            
        }
    }
}
