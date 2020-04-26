namespace TryLog.UseCase.DTO
{
    public class UserLoginInDTO
    {
        public UserLoginInDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
