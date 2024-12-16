using Lms.Application.DTOs;
using Lms.Domain.Models;
using MediatR;

namespace Lms.Application.Queries.Dashboard
{
    public record GetOverdueBorrowersQuery: IRequest<IEnumerable<OverDueBorrowers>>
    {
        
    }
}
