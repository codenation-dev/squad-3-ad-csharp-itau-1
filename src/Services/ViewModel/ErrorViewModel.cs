using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Services.ViewModel
{
    public class ErrorViewModel
    {
        public string Title { get; set; }
        public List<int> Errors { get; set; }
        public string Color { get; set; }
        public List<string> Labels { get; set; }
    }
}
