namespace TryLog.Services.SettingObjects
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FromEmail { get; set; }
    }
}
