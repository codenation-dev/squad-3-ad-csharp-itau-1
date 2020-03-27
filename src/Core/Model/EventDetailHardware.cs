using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
    public class EventDetailHardware
    {
        public long Id { get; set; }
        public long IdEvent { get; set; }
        public string RamMemory { get; set; }
        public string Processor { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Disk { get; set; }
        public string Resolution { get; set; }
        public string AdressMac { get; set; }
        public string DeviceName { get; set; }
    }
}
