using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Lms.Infrastructure.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<IEnumerable<BooksEntity>> GetAllBooksAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                return await connection.QueryAsync<BooksEntity>(
                   "SP_Books",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<BooksEntity?> GetBookByIdAsync(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@BookID", bookId);

                return await connection.QueryFirstOrDefaultAsync<BooksEntity>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<BooksEntity?> AddBookAsync(BooksEntity book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                parameters.Add("@Title", book.Title);
                parameters.Add("@AuthorId", book.AuthorId);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                //parameters.Add("@Quantity", book.Quantity);
                var result = await connection.QueryFirstOrDefaultAsync<BooksEntity>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<BookCopies?> AddBookInstanceAsync(BookCopies bCopy)
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

        public async Task<BooksEntity?> UpdateBookAsync(BooksEntity book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@BookID", book.BookId);
                parameters.Add("@Title", book.Title);
                parameters.Add("@AuthorId", book.AuthorId);
                parameters.Add("@Genre", book.Genre);
                parameters.Add("@ISBN", book.ISBN);
                parameters.Add("@Quantity", book.Quantity);

                var result = await connection.QueryFirstOrDefaultAsync<BooksEntity>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<DeleteOperationResult?> DeleteBookAsync(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@BookID", bookId);

                var result = await connection.QueryFirstOrDefaultAsync<DeleteOperationResult>(
                    "SP_Books",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
