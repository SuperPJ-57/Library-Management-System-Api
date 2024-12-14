using Lms.Application.Commands.BookInstances;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.BookInstancesCommandHandler
{
    public class UpdateBookInstanceCommandHandler:IRequestHandler<UpdateBookInstanceCommand,BookCopies>
    {
        private readonly IBookInstanceRepository _bookInstanceRepository;
        public UpdateBookInstanceCommandHandler(IBookInstanceRepository bookInstanceRepository)
        {
            _bookInstanceRepository = bookInstanceRepository;
        }
        public async Task<BookCopies> Handle(UpdateBookInstanceCommand request, CancellationToken cancellationToken)
        {
            var bookInstance = new BookCopies
            {
                BarCode = request.BarCode,
                BookId = request.BookId,
                IsAvailable = request.IsAvailable

            };
            return await _bookInstanceRepository.UpdateBookInstanceAsync(bookInstance);

        }
    }
}
