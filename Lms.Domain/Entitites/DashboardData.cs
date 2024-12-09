using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Domain.Entitites
{
    public class DashboardData
    {
        public int TotalBorrowedBooks { get; set; }
        public int TotalReturnedBooks { get; set; }
        public int TotalUserBase { get; set; }
        public int TotalBooks { get; set; }
        public int AvailableBooks { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
