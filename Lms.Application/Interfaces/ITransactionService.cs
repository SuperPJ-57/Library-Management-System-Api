using Lms.Application.DTOs;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDetailsDto>> GetAllTransactionsAsync();
        Task<TransactionDetailsDto> GetTransactionByIdAsync(int transactionId);
        Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity transaction);
        Task<TransactionsEntity> UpdateTransactionAsync(TransactionsEntity transaction);
        Task<DeleteOperationResult> DeleteTransactionAsync(int transactionId);
    }
}
