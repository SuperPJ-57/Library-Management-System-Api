using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record TransactionDetailsDto
    {
        public int TransactionId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
}
