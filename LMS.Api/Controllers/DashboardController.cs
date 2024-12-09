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
        public DashboardController(IMediator mediator, IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var dashboardData = await _mediator.Send(new GetDashboardDataQuery(), CancellationToken.None);
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
    }
}
