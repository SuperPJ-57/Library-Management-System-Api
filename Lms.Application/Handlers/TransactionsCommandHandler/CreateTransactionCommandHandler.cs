using Lms.Application.Commands.Transactions;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.TransactionsCommandHandler
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionsEntity>
    {
        private readonly ITransactionService _transactionService;
        public CreateTransactionCommandHandler(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<TransactionsEntity> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new TransactionsEntity
            {
                //TransactionId = request.TransactionId,
                StudentId = request.StudentId,
                UserId = request.UserId,
                BookId = request.BookId,
                BarCode = request.BarCode,
                TransactionType = request.TransactionType,
                Date = request.Date,
                //DueDate = request.Date.AddDays(14)
            };
            return await _transactionService.AddTransactionAsync(transaction);
            
            
        }
    }
}
