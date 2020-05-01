namespace TryLog.Services.ViewModel
{
    public class UserLoginInViewModel
    {
        public UserLoginInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
