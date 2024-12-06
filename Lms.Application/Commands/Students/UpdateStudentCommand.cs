using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Students
{
    public record UpdateStudentCommand:IRequest<StudentsEntity>
    {
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; } = null;

        public string Department { get; set; } = null;

        //public UpdateStudentCommand(int sid, string name, string email, string contactNumber, string department)
        //{
        //    StudentId = sid;
        //    Name = name;
        //    Email = email;
        //    ContactNumber = contactNumber;
        //    Department = department;
        //}
    }
}
