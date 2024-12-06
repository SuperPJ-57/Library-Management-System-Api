using Lms.Application.Utilities;
using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Transactions
{
    public record CreateTransactionCommand: IRequest<TransactionsEntity>
    {
        //public int TransactionId { get; set; }

        public int StudentId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; } = new DateTime(DateTimeUtility.Year,DateTimeUtility.Month,DateTimeUtility.Day);
        

        //public CreateTransactionCommand(int tid, int sid, int uid, int bid, string ttype, DateTime date)
        //{
        //    TransactionId = tid;
        //    StudentId = sid;
        //    UserId = uid;
        //    BookId = bid;
        //    TransactionType = ttype;
        //    Date = date;
        //}

    }
}
