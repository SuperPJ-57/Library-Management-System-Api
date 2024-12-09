using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersEntity?> AuthenticateAsync(string username);
        Task<IEnumerable<UsersEntity>> GetAllUsersAsync();
        Task<UsersEntity> GetUserByUsernameAsync(string username);
        Task<UsersEntity> GetUserByIdAsync(int id);
        Task<string> AddUserAsync(UsersEntity user);
        Task<string> UpdateUserAsync(UsersEntity user);
        Task<string> DeleteUserAsync(int userId);
    }
}
