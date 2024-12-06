using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync();
        Task<TransactionsEntity> GetTransactionByIdAsync(int transactionId);
        Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity transaction);
        Task<TransactionsEntity> UpdateTransactionAsync(TransactionsEntity transaction);
        Task DeleteTransactionAsync(int transactionId);
    }
}
