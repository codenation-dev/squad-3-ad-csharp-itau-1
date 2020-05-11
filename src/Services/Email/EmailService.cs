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
        public void SendAsync(string name, string mailTo, string subject, string body)
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
            //client.Connect(_Settings.PrimaryDomain, _Settings.PrimaryPort, MailKit.Security.SecureSocketOptions.None);
            client.Connect("smtp.gmail.com", 587, false);

            // Note: only needed if the SMTP server requires authentication
            client.Authenticate(_Settings.Email, _Settings.Password);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}

/*        var credentialUserName = _emailSettings.Email;
        var sentFrom = new MailAddress(_emailSettings.FromEmail);
        var pwd = _emailSettings.Password;

        var toAdress = new MailAddress(sentTo);

        SmtpClient client = new SmtpClient()
        {
            Host = _emailSettings.PrimaryDomain,
            Port = _emailSettings.PrimaryPort,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(credentialUserName, pwd)
        };

        using var message = new MailMessage(sentFrom, toAdress)
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        return client.SendMailAsync(message);*/
