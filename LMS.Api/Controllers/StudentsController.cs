using Lms.Application.Commands.Students;
using Lms.Application.DTOs;
using Lms.Application.Queries.Students;
using Lms.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IErrorHandlingService<string> _errorHandlingService;
        public StudentsController(IMediator mediator, IErrorHandlingService<string> errorHandlingService)
        {
            _mediator = mediator;
            _errorHandlingService = errorHandlingService;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            try
            {
                var students = await _mediator.Send(new GetAllStudentsQuery(), CancellationToken.None);
                if (students == null)
                {
                    return NotFound();
                }
                return Ok(students);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

        //get student by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            try
            {
                var query = new GetStudentByIdQuery(id);
                var student = await _mediator.Send(query, CancellationToken.None);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromForm] CreateStudentCommand command)
        {
            try
            {
                var createdStudent = await _mediator.Send(command);
                return Ok(createdStudent);

            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //update students
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromForm] UpdateStudentDto studentDto)
        {
            try
            {
                var command = new UpdateStudentCommand
                {
                    StudentId = id,
                    Name = studentDto.Name,
                    Email = studentDto.Email,
                    ContactNumber = studentDto.ContactNumber,
                    Department = studentDto.Department,

                };
                var updatedStudent = await _mediator.Send(command, CancellationToken.None);
                return Ok(updatedStudent);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }


        //-----------
        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            try
            {
                var command = new DeleteStudentCommand(id);
                var deletedStudent = await _mediator.Send(command, CancellationToken.None);
                if (deletedStudent == null || deletedStudent.Success == 0)
                {
                    return NotFound(deletedStudent);
                }
                return Ok(deletedStudent);
            }
            catch
            {
                var errorMessage = _errorHandlingService.GetError();
                return StatusCode(500, errorMessage);
            }
        }

    }
}
