using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Queries.Users
{
    public record GetUserByUsernameQuery(string Username) : IRequest<UsersEntity>
    {
    }
}
