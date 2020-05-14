using System.ComponentModel.DataAnnotations;

namespace TryLog.Services.ViewModel
{
    public class UserChangePasswordViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string NewPassword { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CurrentPassword { get; set; }       
    }
}
