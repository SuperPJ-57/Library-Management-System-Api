using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Lms.Infrastructure.Repositories
{
    public class AuthorRepository:IAuthorRepository
    {
        private readonly string _connectionString;

        public AuthorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }

        
        public async Task<IEnumerable<AuthorsEntity>?> GetAllAuthorsAsync(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@Query", query);
                return await connection.QueryAsync<AuthorsEntity>(
                   "SP_Authors",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<AuthorsEntity?> GetAuthorByIdAsync(int authorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@AuthorID", authorId);

                var author =  await connection.QueryFirstOrDefaultAsync<AuthorsEntity>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return author;
            }
        }

        public async Task<AuthorsEntity?> AddAuthorAsync(AuthorsEntity author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                //parameters.Add("@AuthorID", author.AuthorId);
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);

                var result = await connection.QueryFirstOrDefaultAsync<AuthorsEntity>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<AuthorsEntity?> UpdateAuthorAsync(AuthorsEntity author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@AuthorID", author.AuthorId);
                parameters.Add("@Name", author.Name);
                parameters.Add("@Bio", author.Bio);

                var result = await connection.QueryFirstOrDefaultAsync<AuthorsEntity>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<DeleteOperationResult?> DeleteAuthorAsync(int authorId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@AuthorID", authorId);

                var result = await connection.QueryFirstOrDefaultAsync<DeleteOperationResult>(
                    "SP_Authors",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
