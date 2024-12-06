using Lms.Domain.Interfaces;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity transaction)
        {
            return await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task DeleteTransactionAsync(int transactionId)
        {
            await _transactionRepository.DeleteTransactionAsync(transactionId);
        }

        public async Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync()
        {
            return await _transactionRepository.GetAllTransactionsAsync();
        }

        public async Task<TransactionsEntity> GetTransactionByIdAsync(int transactionId)
        {
            return await _transactionRepository.GetTransactionByIdAsync(transactionId);
        }

        public async Task<TransactionsEntity> UpdateTransactionAsync(TransactionsEntity transaction)
        {
            return await _transactionRepository.UpdateTransactionAsync(transaction);
        }
    }
}
