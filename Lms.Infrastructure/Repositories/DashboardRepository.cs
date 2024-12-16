using Dapper;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
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
    public class DashboardRepository: IDashboardRepository
    {
        private readonly string _connectionString;

        public DashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }
        public async Task<DashboardData?> GetDashboardDataAsync(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "S");
                parameters.Add("@Username", username);

                return await connection.QueryFirstOrDefaultAsync<DashboardData?>(
                   "SP_Dashboard",
                   parameters,
                   commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<OverDueBorrowers>?> GetOverdueBorrowersAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("@flag", "S");

                return await connection.QueryAsync<OverDueBorrowers?>(
                   "SP_OverdueBorrowers",
                   commandType: CommandType.StoredProcedure);
            }
        }

    }
}
