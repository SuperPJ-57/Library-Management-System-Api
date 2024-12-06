using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record UpdateBookDto
    {
        public string Title { get; set; } = null;
        public int AuthorId { get; set; }
        public string Genre { get; set; } = null;
        public string ISBN { get; set; } = null;
        public int Quantity { get; set; } 
    }
}
