using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Users
{
    public record UpdateUserCommand: IRequest<Unit>
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public UpdateUserCommand(int uid, string username, string password, string email, string role)
        {
            UserId = uid;
            Username = username;
            Password = password;
            Email = email;
            Role = role;
        }
    }
}
