using Lms.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.BookInstances
{
    public record DeleteBookInstanceCommand:IRequest<DeleteOperationResult>
    {
        public int BarCode { get; set; } = 0;
        public DeleteBookInstanceCommand(int barcode)
        {
            BarCode = barcode;
        }
    }
}
