using Lms.Domain.Entitites;

namespace Lms.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardData?> GetDashboardDataAsync();
    }
}
