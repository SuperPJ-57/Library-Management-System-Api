using Lms.Application.Commands.Books;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.BooksCommandHandler
{
    public class CreateBookInstanceCommandHandler : IRequestHandler<CreateBookInstanceCommand, BookCopies>
    {
        private readonly IBookService _bookService;
        public CreateBookInstanceCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<BookCopies> Handle(CreateBookInstanceCommand request, CancellationToken cancellationToken)
        {
            var bookCopy = new BookCopies
            {
                BookId = request.BookId,
                BarCode = request.BarCode
            };
            return await _bookService.AddBookInstanceAsync(bookCopy);
        }
    }
}
