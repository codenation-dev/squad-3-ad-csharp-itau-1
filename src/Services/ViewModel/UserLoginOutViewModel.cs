namespace TryLog.Services.ViewModel
{
    public class UserLoginOutViewModel
    {
        public UserLoginOutViewModel(string result, string message)
        {
            Result = result;
            Message = message;
        }

        public string Result { get; set; }
        public string Message { get; set; }

    }
}
