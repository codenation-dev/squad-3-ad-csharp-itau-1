using Microsoft.Extensions.Options;
using TryLog.Services.SettingObjects;
using MailKit.Net.Smtp;
using MimeKit;
namespace TryLog.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _settings = emailSettings.Value;
        }
        public void Send(string name, string mailTo, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TeamTryLog", _settings.FromEmail));
            message.To.Add(new MailboxAddress(name, mailTo));
            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var client = new SmtpClient();
            client.Connect(_settings.PrimaryDomain, _settings.PrimaryPort, false);

            client.Authenticate(_settings.Email, _settings.Password);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}