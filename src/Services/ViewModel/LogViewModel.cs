using System;
using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class LogViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Token { get; set; }
        [Required]
        public int IdEnvironment { get; set; }
        [Required]
        public int IdLayer { get; set; }
        [Required]
        public int IdSeverity { get; set; }
        [Required]
        public int IdStatus { get; set; }
       
    }
}
