using Lms.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Utilities
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _aspNetPasswordHasher;

        public PasswordHasher()
        {
            _aspNetPasswordHasher = new PasswordHasher<object>();
        }

        public string HashPassword(string password)
        {
            return _aspNetPasswordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var result = _aspNetPasswordHasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }

}
