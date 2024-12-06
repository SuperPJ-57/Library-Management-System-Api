using Lms.Application.Commands.Students;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.StudentsCommandHandler
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentService _studentService;
        public DeleteStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentsEntity
            {
                StudentId = request.StudentId
            };
            await _studentService.DeleteStudentAsync(student.StudentId);
            return Unit.Value;
        }
    }
}
