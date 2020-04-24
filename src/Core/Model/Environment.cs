using System;
using System.Collections.Generic;

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
        public Environment(int id, string description, DateTime dateRegister)
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
