﻿namespace TryLog.Services.ViewModel
{
    public class UserAuthViewModel
    {
        public UserAuthViewModel(string userName, string password, string fullName)
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
        }
        public string UserName { get; set; }
        public string Password { get;  set; }
        public string FullName { get; set; }
    }
}