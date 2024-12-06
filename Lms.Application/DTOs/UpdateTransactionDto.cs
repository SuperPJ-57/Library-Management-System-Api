using Lms.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.DTOs
{
    public record UpdateTransactionDto
    {
        public int StudentId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
        public string TransactionType { get; set; } = null;
        public DateTime Date { get; set; } = new DateTime(DateTimeUtility.Year, DateTimeUtility.Month, DateTimeUtility.Day);

    }
}
