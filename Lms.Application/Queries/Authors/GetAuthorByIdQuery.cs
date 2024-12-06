using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Queries.Authors
{
    public record GetAuthorByIdQuery(int AuthorId): IRequest<AuthorsEntity>
    {
    }
}
