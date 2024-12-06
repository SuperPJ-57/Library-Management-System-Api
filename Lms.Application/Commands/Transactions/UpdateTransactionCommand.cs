using Lms.Application.Utilities;
using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Commands.Transactions
{
    public record UpdateTransactionCommand:IRequest<TransactionsEntity>
    {
        public int TransactionId { get; set; }

        public int StudentId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }


        //public UpdateTransactionCommand(int tid, int sid, int uid, int bid, string ttype, DateTime date)
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
