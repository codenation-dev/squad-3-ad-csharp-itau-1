using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.UseCase.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
       
        public int IdEnvironment { get; set; }
        //public EnvironmentDTO Environment { get; set; }
       
        public int IdLayer { get; set; }
        //public LayerDTO Layer { get; set; }
       
        public int IdSeverity { get; set; }
        //public SeverityDTO Severity { get; set; }
       
        public int IdStatus { get; set; }
        //public StatusDTO Status { get; set; }
    }
}
