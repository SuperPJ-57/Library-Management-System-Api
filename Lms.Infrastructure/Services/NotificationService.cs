using Dapper;
using Lms.Application.DTOs;
using Lms.Application.Interfaces;
using Lms.Domain.Entitites;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IEmailService _emailService;
        private readonly ILogger<NotificationService> _logger;
        private readonly string _connectionString;

        public NotificationService(IDbConnection dbConnection, IEmailService emailService, ILogger<NotificationService> logger, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _emailService = emailService;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("DefaultConnection"); ;
        }

        public async Task<bool> SendNotificationsToOverdueBorrowers()
        {
            try
            {
                
                IEnumerable<OverDueBorrowersDto> overdueBorrowers = null;
                using (var connection = new SqlConnection(_connectionString))
                {
                    

                     overdueBorrowers = await connection.QueryAsync<OverDueBorrowersDto>(
                       "Sp_OverdueBorrowers",
                       commandType: CommandType.StoredProcedure);
                }

                foreach (var borrower in overdueBorrowers)
                {
                    try
                    {
                        // Construct email details
                        var subject = "Overdue Book Reminder";
                        var body = $"Dear {borrower.BorrowerName},\n\n" +
                                   $"You have an overdue book: {borrower.BookTitle}. " +
                                   $"It was due on {borrower.DueDate:yyyy-MM-dd}. " +
                                   $"Please return it as soon as possible.\n\n" +
                                   "Thank you.\nLibrary Team";

                        // Send email
                        await _emailService.SendEmailAsync(borrower.BorrowerEmail, subject, body);

                        // Log success
                        _logger.LogInformation($"Email sent to {borrower.BorrowerEmail} for book: {borrower.BookTitle}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Error sending email to {borrower.BorrowerEmail}: {ex.Message}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in sending notifications: {ex.Message}");
                return false;
            }
        }
    }

}
