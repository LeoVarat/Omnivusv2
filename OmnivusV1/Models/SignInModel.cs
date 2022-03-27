using System.ComponentModel.DataAnnotations;

namespace OmnivusV1.Models
{
    public class SignInModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You have to type in a email")]
        [EmailAddress(ErrorMessage = "The email adress must be valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to type in a password")]
        [StringLength(256, ErrorMessage = "The password has to be at least 8 characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
