using Lms.Application.DTOs;
using Lms.Application.Interfaces;
using Lms.Application.Queries.BookInstances;
using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Handlers.BooksQueryHandler
{
    public class GetAllBookInstancesQueryHandler : IRequestHandler<GetAllBookInstancesQuery, IEnumerable<GetBookInstancesDto>>
    {
        private readonly IBookInstanceService _bookInstanceService;
        public GetAllBookInstancesQueryHandler(IBookInstanceService bookInstanceService)
        {
            _bookInstanceService = bookInstanceService;
        }

        public async Task<IEnumerable<GetBookInstancesDto>> Handle(GetAllBookInstancesQuery request, CancellationToken cancellationToken)
        {
            return await _bookInstanceService.GetAllBookInstancesAsync();
        }
    }
}
