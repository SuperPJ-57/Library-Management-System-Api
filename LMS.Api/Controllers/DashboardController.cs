using Lms.Application.Interfaces;
using Lms.Application.Queries.Books;
using Lms.Application.Queries.Dashboard;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        private readonly INotificationService _notificationService;
        public DashboardController(IMediator mediator, IErrorHandlingService<string> errorHandlingService,INotificationService notificationService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
            _notificationService = notificationService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Details(string username)
        {
            try
            {
                var dashboardData = await _mediator.Send(new GetDashboardDataQuery(username), CancellationToken.None);
                if (dashboardData == null) 
                {
                    return NotFound();
                }
                return Ok(dashboardData);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetOverDueBorrowers()
        {
            try
            {
                var overdueBorrowers = await _mediator.Send(new GetOverdueBorrowersQuery(), CancellationToken.None);
                //_notificationService.SendNotificationsToOverdueBorrowers();
                if (overdueBorrowers == null)
                {
                    return NotFound();
                }
                return Ok(overdueBorrowers);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }
    }
}
