using Lms.Application.Commands.Users;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.UsersCommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        public CreateUserCommandHandler(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;

        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UsersEntity
            {
                UserId = request.UserId,
                Username = request.Username,
                Password = _passwordHasher.HashPassword(request.Password),
                Email = request.Email,
                Role = request.Role
            };
            await _userService.AddUserAsync(user);
            return Unit.Value;

        }
    }
}
