using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Queries.Users
{
    public record AuthenticateUserQuery(string Username,string Password):IRequest<UsersEntity>
    {
    }
}
