using System.ComponentModel.DataAnnotations;


namespace TryLog.Services.ViewModel
{
    public class EnvironmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
