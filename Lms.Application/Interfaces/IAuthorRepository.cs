using Lms.Domain.Entitites;
using Lms.Domain.Models;

namespace Lms.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<AuthorsEntity>?> GetAllAuthorsAsync();
        Task<AuthorsEntity?> GetAuthorByIdAsync(int authorId);
        Task<AuthorsEntity?> AddAuthorAsync(AuthorsEntity author);
        Task<AuthorsEntity?> UpdateAuthorAsync(AuthorsEntity author);
        Task<DeleteOperationResult?> DeleteAuthorAsync(int authorId);
    }
}
