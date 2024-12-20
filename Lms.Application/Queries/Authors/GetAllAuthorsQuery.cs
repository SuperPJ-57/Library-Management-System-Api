using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Queries.Authors
{
    public record GetAllAuthorsQuery(string query): IRequest<IEnumerable<AuthorsEntity>>
    {
    }
}
