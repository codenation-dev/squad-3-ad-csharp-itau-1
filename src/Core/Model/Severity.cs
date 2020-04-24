using System;
using System.Collections.Generic;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Demonstra a Severidade dos Logs: Risco Alto, Risco Médio, Risco Baixo
    /// </summary>
    public class Severity
    {
        public Severity()
        {

        }
        public Severity(int id, string description, DateTime dateRegister)
        {
            Id = id;
            Description = description;
            DateRegister = dateRegister;
            Deleted = false;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
        public IList<Log> Logs { get; set; }
    }
}
