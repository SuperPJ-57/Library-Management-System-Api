using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Books
{
    public record DeleteBookCommand: IRequest<Unit>
    {

        public int BookId { get; set; }
        public DeleteBookCommand(int bid)
        {
            BookId = bid;
        }
    }
}
