using Lms.Application.Queries.Students;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.StudentsQueryHandler
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentsEntity>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<StudentsEntity> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentByIdAsync(request.StudentId);
        }
    }
}
