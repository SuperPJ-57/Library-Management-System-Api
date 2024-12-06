using Lms.Application.Commands.Books;
using Lms.Application.DTOs;
using Lms.Application.Queries.Books;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public BooksController(IMediator mediator, IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var books = await _mediator.Send(new GetAllBooksQuery(), CancellationToken.None);
                if (books == null)
                {
                    return NotFound();
                }
                return Ok(books);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //get book by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            try
            {
                var query = new GetBookByIdQuery(id);
                var book = await _mediator.Send(query, CancellationToken.None);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromForm] CreateBookCommand command)
        {
            try
            {
                var createdBook = await _mediator.Send(command);
                return Ok(createdBook);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //update book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromForm] UpdateBookDto book)
        {
            try
            {
                var command = new UpdateBookCommand {
                    BookId = id,
                    Title = book.Title,
                    AuthorId = book.AuthorId,
                    Genre = book.Genre,
                    ISBN=book.ISBN,
                    Quantity=book.Quantity
                };
                var updatedBook = await _mediator.Send(command, CancellationToken.None) as BooksEntity;
                return Ok(updatedBook);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }
    }
}
