using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Ambiente em qual ocorreu o Evento: Desenvolvimento, Homologação, Produção
    /// </summary>
    public class Environment
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public string Deleted { get; set; }
    }
}
