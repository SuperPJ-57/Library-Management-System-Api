using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Models
{
    public record DeleteOperationResult
    {
        public int Success { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
