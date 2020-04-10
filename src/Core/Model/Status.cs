using System;

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
        public Status(short id, string description, DateTime dateRegister)
        {
            Id = id;
            Description = description;
            DateRegister = dateRegister;
            Deleted = false;
        }

        public short Id { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
    }
}
