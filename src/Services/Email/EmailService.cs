using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Threading.Tasks;
using TryLog.Services.SettingObjects;

namespace TryLog.Services
{
    public class EmailService 
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        
        public Task SendAsync(string sentTo, string subject, string body)
        {
            var credentialUserName = _emailSettings.Email;
            var sentFrom = _emailSettings.FromEmail;
            var pwd = _emailSettings.Password;

            SmtpClient client =
                new SmtpClient(_emailSettings.PrimaryDomain)
                {
                    UseDefaultCredentials = false,
                    Port = _emailSettings.PrimaryPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
           
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            var mail = new MailMessage()
            {
                From=new MailAddress(sentFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(sentTo);
            return client.SendMailAsync(mail);
        }
    }
}