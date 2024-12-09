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
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UsersEntity>
    {
        private readonly IUserService _userService;

        public GetUserByUsernameQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UsersEntity> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByUsernameAsync(request.Username);
        }
    }
}
