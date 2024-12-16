using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Models
{
    public class OverDueBorrowers
    {
        public int BorrowerId { get; set; }
        public int BorrowId { get; set; }
        public string BorrowerName { get; set; }
        public string BorrowerEmail { get; set; }
        public string DueDate { get; set; }
        public string BookTitle { get; set; }
    }
}
