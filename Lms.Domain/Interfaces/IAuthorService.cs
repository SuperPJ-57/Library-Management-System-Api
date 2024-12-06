using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsEntity>> GetAllAuthorsAsync();
        Task<AuthorsEntity> GetAuthorByIdAsync(int authorId);
        Task<AuthorsEntity> AddAuthorAsync(AuthorsEntity author);
        Task<AuthorsEntity> UpdateAuthorAsync(AuthorsEntity author);
        Task DeleteAuthorAsync(int authorId);
    }
}
