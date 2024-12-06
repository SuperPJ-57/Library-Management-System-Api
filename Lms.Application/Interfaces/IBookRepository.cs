using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BooksEntity>> GetAllBooksAsync();
        Task<BooksEntity?> GetBookByIdAsync(int bookId);
        Task<BooksEntity?> AddBookAsync(BooksEntity book);
        Task<BooksEntity?> UpdateBookAsync(BooksEntity book);
        Task<string> DeleteBookAsync(int bookId);

    }
}
