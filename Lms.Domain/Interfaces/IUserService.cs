using Lms.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UsersEntity?> AuthenticateAsync(string username);
        Task<IEnumerable<UsersEntity>> GetAllUsersAsync();
        Task<UsersEntity> GetUserByIdAsync(int userId);
        Task AddUserAsync(UsersEntity user);
        Task UpdateUserAsync(UsersEntity user);
        Task DeleteUserAsync(int userId);
    }
}
