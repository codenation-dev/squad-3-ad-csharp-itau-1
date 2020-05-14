namespace TryLog.Services.SettingObjects
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public double Hours { get; set; }
        public string SecretKey { get; set; }
    }
}