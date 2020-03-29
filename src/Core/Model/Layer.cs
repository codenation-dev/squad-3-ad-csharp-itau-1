using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Diferentes camadas da aplicação: FrontEnd, Back-End, Mobile, Desktop
    /// </summary>
    public class Layer
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public string Deleted { get; set; }
    }
}
