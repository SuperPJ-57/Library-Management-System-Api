using Lms.Domain.Entitites;
using Lms.Domain.Models;

namespace Lms.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardData?> GetDashboardDataAsync(string username);
        Task<IEnumerable<OverDueBorrowers>?> GetOverdueBorrowersAsync();
    }
}
