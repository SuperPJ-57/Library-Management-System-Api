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
        private readonly IUserRepository _userRepository;
        public TransactionService(ITransactionRepository transactionRepository,IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }
        public async Task<TransactionsEntity> AddTransactionAsync(TransactionsEntity transaction)
        {
            var student = await _studentRepository.GetStudentByIdAsync(transaction.StudentId);

            var user = await _userRepository.GetUserByIdAsync(transaction.UserId);
            if (student == null || user == null)
            {
                throw new Exception((student == null) ? "Student not found" : "User not found");
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
