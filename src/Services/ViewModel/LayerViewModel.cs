using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TryLog.Services.ViewModel
{
    public class LayerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
