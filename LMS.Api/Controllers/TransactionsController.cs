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
        public async Task<IActionResult> Details()
        {
            try
            {
                var transaction = await _mediator.Send(new GetAllTransactionsQuery(), CancellationToken.None);
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
                var createdTransaction = await _mediator.Send(command);
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
    }
}
