using Lms.Domain.Interfaces;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task DeleteBookAsync(int bookId)
        {
            await _bookRepository.DeleteBookAsync(bookId);
        }

        public async Task<IEnumerable<BooksEntity>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
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
