using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record OverDueBorrowersDto
    {
        public int BorrowerId { get; set; } 
        public int BorrowId { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerEmail { get; set; }
        public string DueDate { get; set; }
        public string BookTitle { get; set; }
    }
}
