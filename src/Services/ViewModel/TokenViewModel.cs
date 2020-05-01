using System;
namespace TryLog.Services.ViewModel
{
    public class TokenViewModel
    {
        public TokenViewModel(string result)
        {
            Result = result;
        }

        public TokenViewModel(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; }
        public Nullable<DateTime> Expiration { get; }
        public string Result { get; }
    }
}
