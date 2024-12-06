using Lms.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class ErrorHandlingService<T> : IErrorHandlingService<T>
    {
        private T _error;

        public void SetError(T error)
        {
            _error = error;
        }

        public T GetError() => _error;


    }
}
