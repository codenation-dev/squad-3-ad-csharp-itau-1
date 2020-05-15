using System;
using System.Collections.Generic;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Diferentes camadas da aplicação: FrontEnd, Back-End, Mobile, Desktop
    /// </summary>
    public class Layer
    {
        public Layer()
        {
        }
        public Layer(int id, string description)
        {
            Id = id;
            Description = description;
            DateRegister = DateTime.UtcNow;
            Deleted = false;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
        public IList<Log> Logs { get; set; }
    }
}
