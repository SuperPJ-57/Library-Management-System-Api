using Lms.Application.Commands.Students;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.StudentsCommandHandler
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteOperationResult>
    {
        private readonly IStudentService _studentService;
        public DeleteStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<DeleteOperationResult> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentsEntity
            {
                StudentId = request.StudentId
            };
            return await _studentService.DeleteStudentAsync(student.StudentId);
            
        }
    }
}
