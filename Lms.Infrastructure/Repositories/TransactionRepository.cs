using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<IEnumerable<TransactionsEntity>> GetAllTransactionsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                return await connection.QueryAsync<TransactionsEntity>(
                   "SP_Transactions",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<TransactionsEntity?> GetTransactionByIdAsync(int transactionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@TransactionID", transactionId);

                return await connection.QueryFirstOrDefaultAsync<TransactionsEntity>(
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
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

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
                parameters.Add("@TransactionType", transaction.TransactionType);
                parameters.Add("@Date", transaction.Date);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteTransactionAsync(int transactionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@TransactionID", transactionId);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Transactions",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }
    }
}
