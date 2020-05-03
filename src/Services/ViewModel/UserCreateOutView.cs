using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class UserCreateOutView
    {
        public UserCreateOutView(int status)
        {
            Status = status;
        }

        public UserCreateOutView(string email)
        {
            Email = email;
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public int Status { get; set; }
    }
}
