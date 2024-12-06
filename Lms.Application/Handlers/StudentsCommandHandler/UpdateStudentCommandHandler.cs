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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentsEntity>
    {
        private readonly IStudentService _studentService;
        public UpdateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<StudentsEntity> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentsEntity
            {
                StudentId = request.StudentId,
                Name = request.Name,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                Department = request.Department
            };
            return await _studentService.UpdateStudentAsync(student);
            
        }
    }
}
