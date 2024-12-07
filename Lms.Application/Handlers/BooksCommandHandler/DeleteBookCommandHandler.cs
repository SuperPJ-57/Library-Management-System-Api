using Lms.Application.Commands.Books;
using Lms.Domain.Models;
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
    public class DeleteBookCommandHandler: IRequestHandler<DeleteBookCommand,DeleteOperationResult>
    {
        private readonly IBookService _bookService;
        public DeleteBookCommandHandler(IBookService bookService)
        {
            _bookService = bookService;

        }
        public async Task<DeleteOperationResult> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BooksEntity
            {
                BookId = request.BookId,
                
            };
            return await _bookService.DeleteBookAsync(book.BookId);
            
        }
    }
}
