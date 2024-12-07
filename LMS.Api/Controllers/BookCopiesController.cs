using Lms.Application.Commands.Books;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCopiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public BookCopiesController(IMediator mediator, IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        //[HttpGet]
        //public async Task<IActionResult> Details()
        //{
        //    try
        //    {
        //        var books = await _mediator.Send(new GetAllBookInstanceQuery(), CancellationToken.None);
        //        if (books == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(books);

        //    }
        //    catch
        //    {
        //        var errorMessage = _errorHandlingService.GetError();
        //        return StatusCode(500, errorMessage);
        //    }
        //}

        ////get book by id
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetBookById([FromRoute] int id)
        //{
        //    try
        //    {
        //        var query = new GetBookByIdQuery(id);
        //        var book = await _mediator.Send(query, CancellationToken.None);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(book);

        //    }
        //    catch
        //    {
        //        var errorMessage = _errorHandlingService.GetError();
        //        return StatusCode(500, errorMessage);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookInstanceCommand command)
        {
            try
            {
                var createdBookInstance = await _mediator.Send(command);
                return Ok(createdBookInstance);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        
    }
}
