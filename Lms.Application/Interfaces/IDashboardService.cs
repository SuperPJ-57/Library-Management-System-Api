using Lms.Application.DTOs;
using Lms.Domain.Entitites;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardData> GetDashboardDataAsync(string username);
        Task<IEnumerable<OverDueBorrowers>?> GetOverdueBorrowersAsync();
    }
}
