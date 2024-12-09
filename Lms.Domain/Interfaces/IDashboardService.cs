using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardData> GetDashboardDataAsync();
    }
}
