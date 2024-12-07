using Lms.Application.Commands.Transactions;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.TransactionsCommandHandler
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, TransactionsEntity>
    {
        private readonly ITransactionService _transactionService;
        public UpdateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<TransactionsEntity> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new TransactionsEntity
            {
                TransactionId = request.TransactionId,
                StudentId = request.StudentId,
                UserId = request.UserId,
                BookId = request.BookId,
                BarCode = request.BarCode,
                TransactionType = request.TransactionType,
                Date = request.Date
            };
            return await _transactionService.UpdateTransactionAsync(transaction);
            

        }
    }
}
