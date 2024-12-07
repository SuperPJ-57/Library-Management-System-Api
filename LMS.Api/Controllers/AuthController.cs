using Lms.Application.DTOs;
using Lms.Application.Queries.Users;
using Lms.Domain.Interfaces;
using Lms.Infrastructure.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtTokenHelper _jwtTokenHelper;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public AuthController(IMediator mediator,IErrorHandlingService<string> errorHandlingService, JwtTokenHelper jwtTokenHelper)
        {
            _mediator = mediator;
            _jwtTokenHelper = jwtTokenHelper;
            _errorHandlingService = errorHandlingService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                var query = new AuthenticateUserQuery(loginDto.Username, loginDto.Password);
                var user = await _mediator.Send(query, CancellationToken.None);
                if (user == null)
                {
                    return Unauthorized();
                }

                var token = _jwtTokenHelper.GenerateToken(user);
                return Ok(new { token });

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


    }
}
