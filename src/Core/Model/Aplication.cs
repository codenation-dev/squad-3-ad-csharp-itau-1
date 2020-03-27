using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
    public class Aplication
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public DateTime DateRegister { get; set; }
        public string Deleted { get; set; }
    }
}
