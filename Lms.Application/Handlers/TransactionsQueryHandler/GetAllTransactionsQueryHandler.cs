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
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDetailsDto>>
    {
        private readonly ITransactionService _transactionService;
        public GetAllTransactionsQueryHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<IEnumerable<TransactionDetailsDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _transactionService.GetAllTransactionsAsync(request.query);
        }
    }
}
