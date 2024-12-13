using Dapper;
using Lms.Application.DTOs;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Lms.Infrastructure.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<IEnumerable<TransactionDetailsDto>> GetAllTransactionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                return await connection.QueryAsync<TransactionDetailsDto>(
                   "SP_Transactions",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TransactionDetailsDto?> GetTransactionByIdAsync(int transactionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@TransactionID", transactionId);

                return await connection.QueryFirstOrDefaultAsync<TransactionDetailsDto>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TransactionsEntity?> AddTransactionAsync(TransactionsEntity transaction)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                //parameters.Add("@TransactionID", transaction.TransactionId);
                parameters.Add("@StudentId", transaction.StudentId);
                parameters.Add("@UserId", transaction.UserId);
                parameters.Add("@BookId", transaction.BookId);
                parameters.Add("@BarCode", transaction.BarCode);
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);
                parameters.Add("@DueDate", transaction.DueDate);
                var result = await connection.QueryFirstOrDefaultAsync<TransactionsEntity>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                var x = result;

                return result;
            }
        }

        public async Task<TransactionsEntity?> UpdateTransactionAsync(TransactionsEntity transaction)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@TransactionID", transaction.TransactionId);
                parameters.Add("@StudentId", transaction.StudentId);
                parameters.Add("@UserId", transaction.UserId);
                parameters.Add("@BookId", transaction.BookId);
                parameters.Add("@BarCode", transaction.BarCode);
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);

                var result = await connection.QueryFirstOrDefaultAsync<TransactionsEntity>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<DeleteOperationResult?> DeleteTransactionAsync(int transactionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@TransactionID", transactionId);

                var result = await connection.QueryFirstOrDefaultAsync<DeleteOperationResult>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
