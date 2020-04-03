using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Diferentes camadas da aplicação: FrontEnd, Back-End, Mobile, Desktop
    /// </summary>
    public class Layer
    {
        public Layer()
        {
        }
        public Layer(short id, string description, DateTime dateRegister)
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
