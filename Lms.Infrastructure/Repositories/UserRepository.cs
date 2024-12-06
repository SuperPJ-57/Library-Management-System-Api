using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Lms.Infrastructure.Repositories
{
    internal class UserRepository: IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<UsersEntity?> AuthenticateAsync(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "A");
                parameters.Add("@Username", username);
                //parameters.Add("@Password", password);

                return await connection.QueryFirstOrDefaultAsync<UsersEntity>(
                    "SP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<UsersEntity>> GetAllUsersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                return await connection.QueryAsync<UsersEntity>(
                   "SP_Users",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<UsersEntity?> GetUserByIdAsync(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@UserID", userId);

                return await connection.QueryFirstOrDefaultAsync<UsersEntity>(
                    "SP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<string> AddUserAsync(UsersEntity user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@flag", "I");
                //parameters.Add("@UserID", user.UserId); // This is not needed (auto increment
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Role", user.Role);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }

        public async Task<string> UpdateUserAsync(UsersEntity user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@UserID", user.UserId);
                parameters.Add("@Username", user.Username);
                parameters.Add("@Password", user.Password);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Role", user.Role);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }

        public async Task<string> DeleteUserAsync(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@UserID", userId);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_Users",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }

    }
}
