using Lms.Application.Commands.Books;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.BooksCommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BooksEntity>
    {
        private readonly IBookService _bookService;
        public CreateBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<BooksEntity> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BooksEntity
            {
                //BookId = request.BookId,
                Title = request.Title,
                AuthorId = request.AuthorId,
                Genre = request.Genre,
                ISBN = request.ISBN

            };
            return await _bookService.AddBookAsync(book);
            
        }
    }
}
