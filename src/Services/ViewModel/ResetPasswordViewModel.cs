using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
