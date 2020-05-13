using Microsoft.Extensions.Options;
using TryLog.Services.SettingObjects;
using MailKit.Net.Smtp;
using MimeKit;
namespace TryLog.Services
{
    public class EmailService
    {
        private readonly EmailSettings _Settings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _Settings = emailSettings.Value;
        }
        public void Send(string name, string mailTo, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TeamTryLog", _Settings.FromEmail));
            message.To.Add(new MailboxAddress(name, mailTo));
            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var client = new SmtpClient();
            client.Connect(_Settings.PrimaryDomain, _Settings.PrimaryPort, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(_Settings.Email, _Settings.Password);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}