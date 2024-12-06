using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Entitites
{
    public class TransactionsEntity
    {
        public int TransactionId { get; set; }

        public int StudentId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
