using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record UpdateAuthorDto
    {
        public string Name { get; set; } = null;
        public string Bio { get; set; } = null;
    }
}
