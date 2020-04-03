using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Eventos reportados (Excessões, erros)
    /// </summary>
    public class Event
    {
        public Event()
        {
        }

        public long Id { get; set; }
        public Severity Severity { get; set; }
        public Environment Environment { get; set; }
        public Layer Layer { get; set; }
        public Status Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public bool Deleted { get; set; }
    }
}
