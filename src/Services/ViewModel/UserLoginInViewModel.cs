using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class UserLoginInViewModel
    {
        public UserLoginInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get;  set; }
    }
}
