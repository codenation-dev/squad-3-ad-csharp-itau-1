using System.Threading.Tasks;

namespace TryLog.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string name, string email, string subject, string message);
    }
}
