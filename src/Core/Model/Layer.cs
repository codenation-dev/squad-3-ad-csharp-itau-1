using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Diferentes camadas da aplicação: FrontEnd, Back-End, Mobile, Desktop
    /// </summary>
    public class Layer
    {
        public Layer(short id, string code, string description, string active, DateTime dateRegister)
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
