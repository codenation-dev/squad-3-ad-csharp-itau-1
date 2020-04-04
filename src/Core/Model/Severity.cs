using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Demonstra a Severidade dos Eventos: Risco Alto, Risco Médio, Risco Baixo
    /// </summary>
    public class Severity
    {
        public Severity()
        {

        }
        public Severity(short id, string description, DateTime dateRegister)
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
