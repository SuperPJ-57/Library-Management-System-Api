using Lms.Application.Commands.Transactions;
using Lms.Application.DTOs;
using Lms.Application.Queries.Transactions;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public TransactionsController(IMediator mediator, IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromQuery]string? query=null)
        {
            try
            {
                var transaction = await _mediator.Send(new GetAllTransactionsQuery(query), CancellationToken.None);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //get transaction by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById([FromRoute] int id)
        {
            try
            {
                var query = new GetTransactionByIdQuery(id);
                var transaction = await _mediator.Send(query, CancellationToken.None);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromForm] CreateTransactionCommand command)
        {
            try
            {
                var createdTransaction = await _mediator.Send(command,CancellationToken.None);
                return Ok(createdTransaction);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }



        //update transactions
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromRoute] int id, [FromForm] UpdateTransactionDto transactionDto)
        {
            try
            {
                var command = new UpdateTransactionCommand
                {
                    TransactionId = id,
                    StudentId = transactionDto.StudentId,
                    UserId = transactionDto.UserId,
                    BookId = transactionDto.BookId,
                    BarCode = transactionDto.BarCode,
                    TransactionType = transactionDto.TransactionType,
                    Date = transactionDto.Date

                };
                var updatedTransaction = await _mediator.Send(command, CancellationToken.None) ;
                if(updatedTransaction == null)
                {
                    return NotFound();
                }
                return Ok(updatedTransaction);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            try
            {
                var command = new DeleteTransactionCommand(id);
                var deletedTransaction = await _mediator.Send(command, CancellationToken.None);
                if (deletedTransaction == null || deletedTransaction.Success == 0)
                {
                    return BadRequest(deletedTransaction);

                }
                return Ok(deletedTransaction);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }
    }
}
