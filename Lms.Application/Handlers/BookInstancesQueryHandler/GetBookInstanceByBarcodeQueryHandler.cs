using Lms.Application.DTOs;
using Lms.Application.Interfaces;
using Lms.Application.Queries.BookInstances;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.BooksQueryHandler
{
    public class GetBookInstanceByBarcodeQueryHandler : IRequestHandler<GetBookInstanceByBarcodeQuery, GetBookInstancesDto>
    {
        private readonly IBookInstanceService _bookInstanceService;

        public GetBookInstanceByBarcodeQueryHandler(IBookInstanceService bookInstanceService)
        {
            _bookInstanceService = bookInstanceService;
        }
        public async Task<GetBookInstancesDto> Handle(GetBookInstanceByBarcodeQuery request, CancellationToken cancellationToken)
        {
            return await _bookInstanceService.GetBookInstanceByBarcodeAsync(request.barcode);
        }
    }
}
