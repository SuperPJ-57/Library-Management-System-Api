using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Interfaces
{
    public interface IErrorHandlingService<T>
    {
        void SetError(T error);
        T GetError();

    }
}
