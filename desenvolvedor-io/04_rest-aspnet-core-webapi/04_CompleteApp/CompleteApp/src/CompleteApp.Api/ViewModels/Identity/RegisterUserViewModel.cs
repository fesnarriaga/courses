using System.ComponentModel.DataAnnotations;

namespace CompleteApp.Api.ViewModels.Identity
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "{0} is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(100, ErrorMessage = "{0} must be between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password do not match")]
        public string PasswordConfirm { get; set; }
    }
}
