using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
    public class EventDetailSoftware
    {
        public long Id { get; set; }
        public long IdEvent { get; set; }
        public string Ip { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string OperationalSystemName { get; set; }
        public string OperationalSystemVersion { get; set; }
        public string DataBaseName { get; set; }
        public string DataBaseVersion { get; set; }
    }
}
