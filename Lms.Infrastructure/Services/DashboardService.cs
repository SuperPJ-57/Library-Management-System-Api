using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<DashboardData> GetDashboardDataAsync(string username)
        {
            return await _dashboardRepository.GetDashboardDataAsync(username);
        }
        public async Task<IEnumerable<OverDueBorrowers>?> GetOverdueBorrowersAsync()
        {
            return await _dashboardRepository.GetOverdueBorrowersAsync();
        }
        
    }
}
