using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Infraestructure.Model
{
    public class Event
    {
        public long Id { get; set; }
        public int IdAplication {get; set;}
        public short IdSeverity { get; set; }
        public short IdPriority { get; set; }
        public short IdEnvironment { get; set; }
        public short IdLayer { get; set; }
        public short IdStatus { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }
        public string Class { get; set; }
        public string Package { get; set; }        
        public int idType { get; set; }
        public string File { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public bool Deleted { get; set; }
    }
}
