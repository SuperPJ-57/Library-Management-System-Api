using Lms.Application.Interfaces;
using Lms.Application.Queries.Users;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.UsersQueryHandler
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery,UsersEntity>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthenticateUserQueryHandler(IUserService userService, IPasswordHasher passwordHasher) {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }
        public async Task<UsersEntity?> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var user =  await _userService.AuthenticateAsync(request.Username);
            if (_passwordHasher.VerifyPassword(user.Password, request.Password))
            {
                return user;
            }
            return null;
        }
    }
}
