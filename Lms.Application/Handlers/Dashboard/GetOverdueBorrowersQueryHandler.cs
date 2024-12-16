using Lms.Application.DTOs;
using Lms.Application.Queries.Dashboard;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.Dashboard
{
    public class GetOverdueBorrowersQueryHandler: IRequestHandler<GetOverdueBorrowersQuery,IEnumerable<OverDueBorrowers>>
    {
        private readonly IDashboardService _dashboardService;

        public GetOverdueBorrowersQueryHandler(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        public async Task<IEnumerable<OverDueBorrowers>> Handle(GetOverdueBorrowersQuery request, CancellationToken cancellationToken)
        {
            var result =  await _dashboardService.GetOverdueBorrowersAsync();
            return result;
        }
    }
}
