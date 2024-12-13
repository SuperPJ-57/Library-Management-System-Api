using Lms.Application.DTOs;
using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Queries.Transactions
{
    public record GetTransactionByIdQuery (int TransactionId): IRequest<TransactionDetailsDto>
    {
    }
}
