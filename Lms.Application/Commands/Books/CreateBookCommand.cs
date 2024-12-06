using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Books
{
    public record CreateBookCommand:IRequest<BooksEntity>
    {
        //public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        //public CreateBookCommand(int bid, string title, int aid, string genre, string isbn, int quantity)
        //{
        //    Title = title;
        //    BookId = bid;
        //    AuthorId = aid;
        //    Genre = genre;
        //    ISBN = isbn;
        //    Quantity = quantity;
        //}
        //public CreateBookCommand() { }
    }
}
