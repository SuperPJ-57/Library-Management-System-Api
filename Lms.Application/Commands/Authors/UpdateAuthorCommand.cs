using Lms.Domain.Entitites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Authors
{
    public record UpdateAuthorCommand:IRequest<AuthorsEntity>
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } 
        public string Bio { get; set; } 
        //public UpdateAuthorCommand(int aid, string name, string bio)
        //{
        //    AuthorId = aid;
        //    Name = name;
        //    Bio = bio;
        //}

    }
}
