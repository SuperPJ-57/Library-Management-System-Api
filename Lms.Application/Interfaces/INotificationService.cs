using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendNotificationsToOverdueBorrowers();
    }
}
