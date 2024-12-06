using Lms.Application.Queries.Authors;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.AuthorsQueryHandler
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorsEntity>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorByIdQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<AuthorsEntity> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAuthorByIdAsync(request.AuthorId);
        }
    }
}
