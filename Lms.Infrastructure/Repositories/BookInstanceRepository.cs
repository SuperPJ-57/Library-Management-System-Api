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
    public class BookInstanceRepository:IBookInstanceRepository
    {
        private readonly string _connectionString;

        public BookInstanceRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<IEnumerable<GetBookInstancesDto>> GetAllBookInstancesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                var result = await connection.QueryAsync<GetBookInstancesDto>(
                   "SP_BookInstance",
                   parameters,
                   commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<GetBookInstancesDto> GetBookInstanceByBarcodeAsync(int barcode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@BarCode", barcode);

                return await connection.QueryFirstOrDefaultAsync<GetBookInstancesDto>(
                    "SP_BookInstance",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        

        public async Task<BookCopies> AddBookInstanceAsync(BookCopies bCopy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                parameters.Add("@BookId", bCopy.BookId);
                parameters.Add("@BarCode", bCopy.BarCode);
                var result = await connection.QueryFirstOrDefaultAsync<BookCopies>(
                    "Sp_BookInstance",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<BookCopies> UpdateBookInstanceAsync(BookCopies bCopy)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@BookId", bCopy.BookId);
                parameters.Add("@BarCode", bCopy.BarCode);
                parameters.Add("@IsAvailable", bCopy.IsAvailable);
                var result = await connection.QueryFirstOrDefaultAsync<BookCopies>(
                    "SP_BookInstance",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<DeleteOperationResult> DeleteBookInstanceAsync(int barcode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@BarCode", barcode);

                var result = await connection.QueryFirstOrDefaultAsync<DeleteOperationResult>(
                    "SP_BookInstance",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
