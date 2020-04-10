using System;

namespace TryLog.Core.Model
{
    /// <summary>
    /// Ambiente em qual ocorreu o Log: Desenvolvimento, Homologação, Produção
    /// </summary>
    public class Environment
    {
        public Environment()
        {

        }
        public Environment(short id, string description, DateTime dateRegister)
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
