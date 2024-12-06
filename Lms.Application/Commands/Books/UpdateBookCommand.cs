using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Commands.Books
{
    public record UpdateBookCommand: IRequest<BooksEntity>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int Quantity { get; set; }
        //public UpdateBookCommand(int bid, string title, int aid, string genre, string isbn, int quantity)
        //{
        //    Title = title;
        //    BookId = bid;
        //    AuthorId = aid;
        //    Genre = genre;
        //    ISBN = isbn;
        //    Quantity = quantity;
        //}
    }
}
