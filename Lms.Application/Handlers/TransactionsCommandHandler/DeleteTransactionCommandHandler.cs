using Lms.Application.Commands.Transactions;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;
using MediatR;

namespace Lms.Application.Handlers.TransactionsCommandHandler
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, DeleteOperationResult>
    {
        private readonly ITransactionService _transactionService;
        public DeleteTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<DeleteOperationResult> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new TransactionsEntity
            {
                TransactionId = request.TransactionId
            };
            return await _transactionService.DeleteTransactionAsync(transaction.TransactionId);
            

        }
    }
}
