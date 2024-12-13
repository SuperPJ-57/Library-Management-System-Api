using Lms.Application.DTOs;
using Lms.Application.Queries.Transactions;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.TransactionsQueryHandler
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDetailsDto>
    {
        private readonly ITransactionService _transactionService;

        public GetTransactionByIdQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<TransactionDetailsDto> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetTransactionByIdAsync(request.TransactionId);
        }
    }
}
