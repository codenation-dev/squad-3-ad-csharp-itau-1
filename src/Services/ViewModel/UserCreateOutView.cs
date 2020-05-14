namespace TryLog.Services.ViewModel
{
    public class UserCreateOutView
    {
        public UserCreateOutView(int statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }

        public int StatusCode { get; set; }

        public string Description { get; set; }
    }
}
