using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Lms.Infrastructure.Repositories
{
    internal class StudentRepository: IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<IEnumerable<StudentsEntity>> GetAllStudentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");

                return await connection.QueryAsync<StudentsEntity>(
                   "SP_Students",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<StudentsEntity?> GetStudentByIdAsync(int studentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@StudentID", studentId);

                return await connection.QueryFirstOrDefaultAsync<StudentsEntity>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<StudentsEntity?> AddStudentAsync(StudentsEntity student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                //parameters.Add("@StudentID", student.StudentId);
                parameters.Add("@Name", student.Name);
                parameters.Add("@Email", student.Email);
                parameters.Add("@ContactNumber", student.ContactNumber);
                parameters.Add("@Department", student.Department);

                var result = await connection.QueryFirstOrDefaultAsync<StudentsEntity>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<StudentsEntity?> UpdateStudentAsync(StudentsEntity student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@StudentID", student.StudentId);
                parameters.Add("@Name", student.Name);
                parameters.Add("@Email", student.Email);
                parameters.Add("@ContactNumber", student.ContactNumber);
                parameters.Add("@Department", student.Department);

                var result = await connection.QueryFirstOrDefaultAsync<StudentsEntity>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<DeleteOperationResult?> DeleteStudentAsync(int studentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@StudentID", studentId);

                var result = await connection.QueryFirstOrDefaultAsync<DeleteOperationResult>(
                    "SP_Students",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
