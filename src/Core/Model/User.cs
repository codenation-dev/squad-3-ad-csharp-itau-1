using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Representa o usu�rio da aplica��o.
    /// </summary>

    public class User:IdentityUser<string>
    {
        public User(string fullName, string userName)
            :base(userName:userName)
        {
            Id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            FullName = fullName;
            Email = userName;
            CreatedAt = DateTime.UtcNow ;
            UpdatedAt = CreatedAt;
            Deleted = false;
        }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }
    }

}
