using Microsoft.Extensions.Options;
using TryLog.Services.SettingObjects;
using MailKit.Net.Smtp;
using MimeKit;
using TryLog.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace TryLog.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _settings = emailSettings.Value;
        }
        public async Task SendEmailAsync(string name, string email, string subject, string bodyMessage)
        {
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("TeamTryLog", _settings.FromEmail));

                message.To.Add(new MailboxAddress(name, email));

                message.Subject = subject;

                message.Body = new TextPart("html")
                {
                    Text = bodyMessage
                };

                using (var client = new SmtpClient())
                {
                    // Accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_settings.PrimaryDomain);
                    
                    // Note: only needed if the SMTP server requires authentication
                    await client.AuthenticateAsync(_settings.Email.ToString(), _settings.Password.ToString());

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}