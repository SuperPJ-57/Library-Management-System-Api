using Lms.Application.Queries.Dashboard;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;

namespace Lms.Application.Handlers.Dashboard
{
    public class GetDashboardDataQueryHandler: IRequestHandler<GetDashboardDataQuery, DashboardData>
    {
        private readonly IDashboardService _dashboardService;

        public GetDashboardDataQueryHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public async Task<DashboardData> Handle(GetDashboardDataQuery request, CancellationToken cancellationToken)
        {
            return await _dashboardService.GetDashboardDataAsync(request.Username);
        }
    }
}
