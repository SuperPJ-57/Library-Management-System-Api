using Lms.Application.Commands.Users;
using Lms.Domain.Entitites;
using Lms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Handlers.UsersCommandHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserService _userService;
        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UsersEntity
            {
                UserId = request.UserId,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                Role = request.Role
            };
            await _userService.UpdateUserAsync(user);
            return Unit.Value;

        }
    }
}
