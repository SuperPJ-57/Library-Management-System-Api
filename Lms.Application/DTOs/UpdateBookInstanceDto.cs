using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public class UpdateBookInstanceDto
    {
        public int BookId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
