using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
    public class EventStatusTracking
    {
        public long Id { get; set; }
        public long IdEvent { get; set; }
        public short IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
