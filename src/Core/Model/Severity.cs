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
        public Severity(short id, string code, string description, string active, DateTime dateRegister)
        {
            Id = id;
            Code = code;
            Description = description;
            Active = active;
            DateRegister = dateRegister;
            Deleted = false;
        }

        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
    }
}
