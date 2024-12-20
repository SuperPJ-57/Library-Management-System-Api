using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Queries.Books
{
    public record GetAllBooksQuery(string? query): IRequest<IEnumerable<BooksEntity>>
    {
    }
}
