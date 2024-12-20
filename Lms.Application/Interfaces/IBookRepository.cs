using Lms.Domain.Entitites;
using Lms.Domain.Models;

namespace Lms.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<BooksEntity>> GetAllBooksAsync(string query);
        Task<BooksEntity?> GetBookByIdAsync(int bookId);
        Task<BooksEntity?> AddBookAsync(BooksEntity book);
        Task<BooksEntity?> UpdateBookAsync(BooksEntity book);
        Task<DeleteOperationResult?> DeleteBookAsync(int bookId);

    }
}
