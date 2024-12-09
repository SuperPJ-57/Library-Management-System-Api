using Lms.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("SendOverdueNotifications")]
        public async Task<IActionResult> SendOverdueNotifications()
        {
            var result = await _notificationService.SendNotificationsToOverdueBorrowers();
            if (result)
                return Ok(new { message = "Notifications sent successfully." });

            return StatusCode(500, "An error occurred while sending notifications.");
        }
    }
}
