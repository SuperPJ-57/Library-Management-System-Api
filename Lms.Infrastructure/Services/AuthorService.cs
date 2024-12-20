using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using Lms.Domain.Models;

namespace Lms.Infrastructure.Services
{
    public class AuthorService: IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author)
        {
            return await _authorRepository.AddAuthorAsync(author);
        }

        public async Task<DeleteOperationResult> DeleteAuthorAsync(int authorId)
        {
            return await _authorRepository.DeleteAuthorAsync(authorId);
        }

        public async Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync(string query)
        {
            return await _authorRepository.GetAllAuthorsAsync(query);
        }

        public async Task<AuthorsEntity> GetAuthorByIdAsync(int authorId)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(authorId);
            return author;
        }

        public async Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author)
        {
            return await _authorRepository.UpdateAuthorAsync(author);
        }
    }
}
