using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Core.Model
{
  
    public class User
    {

        public long Id { get; set; }
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
