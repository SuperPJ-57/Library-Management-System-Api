using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record UpdateStudentDto
    {
        public string Name { get; set; } = null;

        public string Email { get; set; } = null;

        public string ContactNumber { get; set; } = null;

        public string Department { get; set; } = null;
    }
}
