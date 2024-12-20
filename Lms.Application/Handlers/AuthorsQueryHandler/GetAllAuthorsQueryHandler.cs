using Lms.Application.Queries.Authors;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;

namespace Lms.Application.Handlers.AuthorsQueryHandler
{
    public class GetAllAuthorsQueryHandler: IRequestHandler<GetAllAuthorsQuery,IEnumerable<AuthorsEntity>>
    {
        private readonly IAuthorService _authorService;
        public GetAllAuthorsQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IEnumerable<AuthorsEntity>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAllAuthorsAsync(request.query);
        }
    }
}
