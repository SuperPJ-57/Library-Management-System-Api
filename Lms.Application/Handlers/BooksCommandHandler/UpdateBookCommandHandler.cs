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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BooksEntity>
    {
        private readonly IBookService _bookService;
        public UpdateBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<BooksEntity> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BooksEntity
            {
                BookId = request.BookId,
                Title = request.Title,
                AuthorId = request.AuthorId,
                Genre = request.Genre,
                ISBN = request.ISBN,
                Quantity = request.Quantity
            };
            return await _bookService.UpdateBookAsync(book);
            
        }
    }
}
