using Lms.Domain.Interfaces;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;

namespace Lms.Infrastructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersEntity?> AuthenticateAsync(string username)
        {
            var user = await _userRepository.AuthenticateAsync(username);
            return user;
            
        }
        public async Task AddUserAsync(UsersEntity user)
        {
            
            await _userRepository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UsersEntity>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<UsersEntity> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task UpdateUserAsync(UsersEntity user)
        {
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
