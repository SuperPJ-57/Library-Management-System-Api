using Lms.Domain.Entitites;
using Lms.Domain.Models;


namespace Lms.Domain.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync();
        Task<AuthorsEntity> GetAuthorByIdAsync(int authorId);
        Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author);
        Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author);
        Task<DeleteOperationResult> DeleteAuthorAsync(int authorId);
    }
}
