using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.BookInstances
{
    public record UpdateBookInstanceCommand:IRequest<BookCopies>
    {
        public int BarCode { get; set; }
        public int BookId { get; set; }
        public bool IsAvailable { get; set; }

    }
}
