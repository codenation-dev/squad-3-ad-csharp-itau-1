using System;

namespace TryLog.Infraestructure.Model
{
    /// <summary>
    /// Possuí o Status dos Eventos, por exemplo: Arquivado, Pendente, Ignorado
    /// </summary>
    public class Status
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public string Deleted { get; set; }
    }
}
