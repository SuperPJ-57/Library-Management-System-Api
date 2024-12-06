using Lms.Application.Commands.Users;
using Lms.Application.Queries.Users;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;

        public UsersController(IMediator mediator,IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserCommand user)
        {
            try
            {
                var result = await _mediator.Send(user);
                return Ok();

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            try
            {
                var query = new GetUserByIdQuery(id);
                var user = await _mediator.Send(query, CancellationToken.None);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }


        //getalluser, getuserbyusername,  updateuser, deleteuser
    }
}
