using Lms.Application.Commands.Books;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.BooksCommandHandler
{
    public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommand,Unit>
    {
        private readonly IBookService _bookService;
        public DeleteBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;

        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BooksEntity
            {
                BookId = request.BookId,
                
            };
            await _bookService.DeleteBookAsync(book.BookId);
            return Unit.Value;
        }
    }
}
