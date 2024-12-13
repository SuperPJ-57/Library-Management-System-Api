using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Entitites
{
    public class AuthorsEntity
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = null;
        public string Bio { get; set; } = null;
    }
}
