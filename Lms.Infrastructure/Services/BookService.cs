using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;

namespace Lms.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<BooksEntity> AddBookAsync(BooksEntity book)
        {
            return await _bookRepository.AddBookAsync(book);
        }
        
        public async Task<DeleteOperationResult> DeleteBookAsync(int bookId)
        {
            return await _bookRepository.DeleteBookAsync(bookId);
        }

        public async Task<IEnumerable<BooksEntity>> GetAllBooksAsync(string query)
        {
            return await _bookRepository.GetAllBooksAsync(query);
        }

        public async Task<BooksEntity> GetBookByIdAsync(int bookId)
        {
            return await _bookRepository.GetBookByIdAsync(bookId);
        }

        public async Task<BooksEntity> UpdateBookAsync(BooksEntity book)
        {
            return await _bookRepository.UpdateBookAsync(book);
        }
    }
}
