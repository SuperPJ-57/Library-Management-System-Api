using Lms.Application.Commands.BookInstances;
using Lms.Application.Commands.Books;
using Lms.Application.DTOs;
using Lms.Application.Queries.BookInstances;
using Lms.Application.Queries.Books;
using Lms.Domain.Entitites;
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

        

        [HttpPost]
        public async Task<IActionResult> CreateBookInstance([FromForm] CreateBookInstanceCommand command)
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

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var bookCopies = await _mediator.Send(new GetAllBookInstancesQuery(), CancellationToken.None);
                if (bookCopies == null)
                {
                    return NotFound();
                }
                return Ok(bookCopies);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //get book by barcode
        [HttpGet("{barcode}")]
        public async Task<IActionResult> GetBookInstanceByBarcode([FromRoute] int barcode)
        {
            try
            {
                var query = new GetBookInstanceByBarcodeQuery(barcode);
                var bCopy = await _mediator.Send(query, CancellationToken.None);
                if (bCopy == null)
                {
                    return NotFound();
                }
                return Ok(bCopy);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }

        [HttpPut("{barcode}")]
        public async Task<IActionResult> UpdateBookInstance([FromRoute] int barcode, [FromForm] UpdateBookInstanceDto update)
        {
            try
            {
                var command = new UpdateBookInstanceCommand { BarCode = barcode, BookId = update.BookId, IsAvailable = update.IsAvailable };
                var updatedBook = await _mediator.Send(command, CancellationToken.None);
                return Ok(updatedBook);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //-------------
        //delete
        [HttpDelete("{barcode}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int barcode)
        {
            try
            {
                var command = new DeleteBookInstanceCommand(barcode);
                var deletedBookInstance = await _mediator.Send(command, CancellationToken.None);
                if (deletedBookInstance == null || deletedBookInstance.Success == 0)
                {
                    return NotFound(deletedBookInstance);
                }
                return Ok(deletedBookInstance);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }
    }
}
