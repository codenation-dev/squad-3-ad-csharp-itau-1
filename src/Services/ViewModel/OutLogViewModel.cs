using System;
using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class OutLogViewModel
    {
        public int Id { get; set; }        
        public string Description { get; set; }
        public DateTime DateRegister { get; set; }
        public string Token { get; set; }        
        public EnvironmentViewModel Environment { get; set; }        
        public LayerViewModel Layer { get; set; }        
        public SeverityViewModel Severity { get; set; }        
        public StatusViewModel Status { get; set; }
        public int Frequency { get; set; }
    }
}
