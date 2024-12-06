using Lms.Application.Queries.Books;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.BooksQueryHandler
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BooksEntity>
    {
        private readonly IBookService _bookService;

        public GetBookByIdQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<BooksEntity> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBookByIdAsync(request.BookId);
        }
    }
}
