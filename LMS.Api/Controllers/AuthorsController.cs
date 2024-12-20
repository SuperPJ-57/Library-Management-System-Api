using Lms.Application.Commands.Authors;
using Lms.Application.DTOs;
using Lms.Application.Queries.Authors;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public AuthorsController(IMediator mediator,IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        //get all authors
        [HttpGet]
        public async Task<IActionResult> Details([FromQuery]string? query=null)
        {
            try
            {
                var authors = await _mediator.Send(new GetAllAuthorsQuery(HttpUtility.UrlDecode(query)), CancellationToken.None);
                if(authors == null)
                {
                    return NotFound(); 
                }
                return Ok(authors);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //get authors by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] int id)
        {
            try
            {
                var query = new GetAuthorByIdQuery(id);
                var author = await _mediator.Send(query, CancellationToken.None);
                if(author == null)
                {
                    return NotFound();
                }
                return Ok(author);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }

        //create author
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromForm]CreateAuthorCommand command)
        {
            try
            {
                var createdAuthor = await _mediator.Send(command);
                return Ok(createdAuthor);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //update author
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromRoute] int id,[FromForm] UpdateAuthorDto author)
        {
            try
            {
                var command = new UpdateAuthorCommand {
                    AuthorId = id,
                    Name = author.Name,
                    Bio = author.Bio
                };
                var updatedAuthor = await _mediator.Send(command,CancellationToken.None);
                return Ok(updatedAuthor);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
        {
            try
            {
                var command = new DeleteAuthorCommand(id);
                var deletedAuthor = await _mediator.Send(command, CancellationToken.None);
                if (deletedAuthor == null || deletedAuthor.Success == 0)
                {
                    return NotFound(deletedAuthor);
                }
                return Ok(deletedAuthor);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }
    }
}
