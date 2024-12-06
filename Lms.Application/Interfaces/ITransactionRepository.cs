using Lms.Domain.Entitites;

namespace Lms.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync();
        Task<TransactionsEntity?> GetTransactionByIdAsync(int transactionId);
        Task<TransactionsEntity?> AddTransactionAsync(TransactionsEntity transaction);
        Task<TransactionsEntity?> UpdateTransactionAsync(TransactionsEntity transaction);
        Task<string> DeleteTransactionAsync(int transactionId);
    }
}
