using Lms.Domain.Entitites;
using MediatR;

namespace Lms.Application.Commands.Authors
{
    public record DeleteAuthorCommand: IRequest<Unit>
    {
        public DeleteAuthorCommand(int aid)
        {
            AuthorId = aid;
        }
        public int AuthorId { get; set; }
    }
}
