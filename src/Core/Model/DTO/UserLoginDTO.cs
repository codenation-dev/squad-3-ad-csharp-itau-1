using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TryLog.Core.Model.DTO
{
    public class UserLoginDTO
    {
        public UserLoginDTO(string email, string password, string token)
        {
            Email = email;
            Password = password;
            Token = token;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Token { get; set; }
    }
}
