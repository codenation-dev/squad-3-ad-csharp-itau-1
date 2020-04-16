using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Representa o usuário da aplicação.
    /// </summary>

    public class User:IdentityUser<string>
    {
        public User(string userName, string fullName,  string email, string password, DateTime createdAt, DateTime updatedAt)
            :base(userName:userName)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            FullName = fullName;
            Email = email;
            Password = password;
            CreatedAt = DateTime.Now ;
            UpdatedAt = DateTime.Now;
            Deleted = false;
        }
        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }

}
