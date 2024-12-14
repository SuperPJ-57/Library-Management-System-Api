using Lms.Application.Commands.BookInstances;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Handlers.BookInstancesCommandHandler
{
    public class CreateBookInstanceCommandHandler : IRequestHandler<CreateBookInstanceCommand, BookCopies>
    {
        private readonly IBookInstanceService _bookInstanceService;
        public CreateBookInstanceCommandHandler(IBookInstanceService bookInstanceService)
        {
            _bookInstanceService = bookInstanceService;
        }
        public async Task<BookCopies> Handle(CreateBookInstanceCommand request, CancellationToken cancellationToken)
        {
            var bookInstanceCopy = new BookCopies
            {
                BookId = request.BookId,
                BarCode = request.BarCode
            };
            return await _bookInstanceService.AddBookInstanceAsync(bookInstanceCopy);
        }
    }
}
