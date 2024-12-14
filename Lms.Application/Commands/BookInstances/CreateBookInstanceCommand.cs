using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.BookInstances
{
    public record CreateBookInstanceCommand : IRequest<BookCopies>
    {
        public int BookId { get; set; }
        public int BarCode { get; set; }
    }
}
