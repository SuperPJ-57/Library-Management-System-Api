using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;

namespace Lms.Infrastructure.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStudentRepository _studentRepository;
        public TransactionService(ITransactionRepository transactionRepository,IStudentRepository studentRepository)
        {
            _transactionRepository = transactionRepository;
            _studentRepository = studentRepository;
        }
        public async Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity transaction)
        {
            var result = await _studentRepository.GetStudentByIdAsync(transaction.StudentId);
            if(result == null)
            {
                throw new Exception("Student not found");
            }
            return await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task<DeleteOperationResult> DeleteTransactionAsync(int transactionId)
        {
            return await _transactionRepository.DeleteTransactionAsync(transactionId);
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
