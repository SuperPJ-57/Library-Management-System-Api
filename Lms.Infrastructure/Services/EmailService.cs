using Lms.Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Lms.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                emailSettings["SenderName"], emailSettings["SenderEmail"]));
            message.To.Add(new MailboxAddress(toEmail, toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { TextBody = body };
            message.Body = bodyBuilder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            try
            {
                await smtpClient.ConnectAsync(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                await smtpClient.SendAsync(message);
            }
            finally
            {
                await smtpClient.DisconnectAsync(true);
            }
        }
    }

}
