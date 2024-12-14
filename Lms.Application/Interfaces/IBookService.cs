using Lms.Domain.Entitites;
using Lms.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BooksEntity>> GetAllBooksAsync();
        Task<BooksEntity> GetBookByIdAsync(int bookId);
        Task<BooksEntity> AddBookAsync(BooksEntity book);
        
        Task<BooksEntity> UpdateBookAsync(BooksEntity book);
        Task<DeleteOperationResult> DeleteBookAsync(int bookId);
    }
}
