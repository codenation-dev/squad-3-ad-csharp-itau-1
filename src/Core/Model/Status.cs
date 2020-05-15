using System;
using System.Collections.Generic;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Possuí o Status dos Logs, por exemplo: Arquivado, Pendente, Ignorado
    /// </summary>
    public class Status
    {
        public Status()
        {
        }
        public Status(int id, string description)
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
