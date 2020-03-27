using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
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
