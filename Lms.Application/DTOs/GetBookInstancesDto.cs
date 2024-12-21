using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record GetBookInstancesDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int BarCode { get; set; }
        public bool IsAvailable { get; set; }
    }
}
