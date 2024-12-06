using MediatR;
using Lms.Domain.Entitites;

namespace Lms.Application.Commands.Authors
{
    public record CreateAuthorCommand: IRequest<AuthorsEntity>
    {
        public CreateAuthorCommand()
        {
            
        }
        //public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; } = null;
    }
}
