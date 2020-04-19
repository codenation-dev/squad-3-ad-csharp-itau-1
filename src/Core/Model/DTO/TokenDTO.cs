using System;
namespace TryLog.Core.Model.DTO
{
    public class TokenDTO
    {
        public TokenDTO(string result)
        {
            Result = result;
        }

        public TokenDTO(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }

        public string Token { get; }
        public Nullable<DateTime> Expiration { get; }
        public string Result { get; }
    }
}
