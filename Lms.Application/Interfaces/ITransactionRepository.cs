using Lms.Domain.Entitites;
using Lms.Domain.Models;

namespace Lms.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync();
        Task<TransactionsEntity?> GetTransactionByIdAsync(int transactionId);
        Task<TransactionsEntity?> AddTransactionAsync(TransactionsEntity transaction);
        Task<TransactionsEntity?> UpdateTransactionAsync(TransactionsEntity transaction);
        Task<DeleteOperationResult?> DeleteTransactionAsync(int transactionId);
    }
}
