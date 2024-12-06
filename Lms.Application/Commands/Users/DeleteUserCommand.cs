using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Users
{
    public record DeleteUserCommand: IRequest<Unit>
    {
        public int UserId { get; set; }
        public DeleteUserCommand(int uid)
        {
            UserId = uid;
        }
    }
}
