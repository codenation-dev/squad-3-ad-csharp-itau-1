using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Demonstra a Severidade dos Eventos: Risco Alto, Risco Médio, Risco Baixo
    /// </summary>
    public class Severity
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public string Deleted { get; set; }
    }
}
