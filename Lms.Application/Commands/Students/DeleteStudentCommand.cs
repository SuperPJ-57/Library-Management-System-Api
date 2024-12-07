using Lms.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Students
{
    public record DeleteStudentCommand : IRequest<DeleteOperationResult>
    {
        public DeleteStudentCommand(int sid)
        {
            StudentId = sid;
        }
        public int StudentId { get; set; }
    }
}
