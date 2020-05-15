using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Logs reportados (Excessões, erros)
    /// </summary>
    public class Log
    {
        public Log()
        {
            DateRegister = DateTime.UtcNow;
            Deleted = false;
        }

        public int Id { get; set; }   
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
        public string Token { get; set; }

        public int IdEnvironment { get; set; }
        public Environment Environment { get; set; }

        public int IdLayer { get; set; }
        public Layer Layer { get; set; }

        public int IdSeverity { get; set; }
        public Severity Severity { get; set; }

        public int IdStatus { get; set; }
        public Status Status { get; set; }
    }
}
