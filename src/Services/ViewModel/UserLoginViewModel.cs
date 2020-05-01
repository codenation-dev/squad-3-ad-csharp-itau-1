using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TryLog.Services.ViewModel
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(string email, string password, string token)
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
