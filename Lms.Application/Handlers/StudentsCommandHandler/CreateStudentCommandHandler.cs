using Lms.Application.Commands.Students;
using Lms.Application.Commands.Students;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lms.Application.Handlers.StudentsCommandHandler
{
    public class CreateStudentCommandHandler: IRequestHandler<CreateStudentCommand,StudentsEntity>
    {
        private readonly IStudentService _studentService;
        public CreateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<StudentsEntity> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new StudentsEntity
            {
                //StudentId = request.StudentId,
                Name = request.Name,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                Department = request.Department
            };
            return await _studentService.AddStudentAsync(student);
            
        }
    }
}
