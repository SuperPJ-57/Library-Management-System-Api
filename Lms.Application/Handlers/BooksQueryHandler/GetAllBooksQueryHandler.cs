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
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BooksEntity>>
    {
        private readonly IBookService _bookService;
        public GetAllBooksQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IEnumerable<BooksEntity>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _bookService.GetAllBooksAsync();
        }
    }
}
