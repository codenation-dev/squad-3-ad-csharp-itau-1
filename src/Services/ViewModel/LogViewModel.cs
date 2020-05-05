using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Services.ViewModel
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Token { get; set; }
        public int IdEnvironment { get; set; }
        public int IdLayer { get; set; }
        public int IdSeverity { get; set; }
        public int IdStatus { get; set; }       
    }
}
