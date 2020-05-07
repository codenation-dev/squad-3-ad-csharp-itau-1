using Microsoft.AspNetCore.Identity;
using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Representa o usuário da aplicação.
    /// </summary>

    public class User : IdentityUser
    {
        public User(string fullName, string userName, string password)
            : base(userName: userName)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            FullName = fullName;
            Email = userName;
            Password = password;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
            Deleted = false;
        }

        public string FullName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }
}
