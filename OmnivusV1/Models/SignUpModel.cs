using System.ComponentModel.DataAnnotations;

namespace OmnivusV1.Models
{
    public class SignUpModel
    {
        [Display(Name = "Firstname")]
        [Required(ErrorMessage = "Firstname is missing")]
        [StringLength(256, ErrorMessage = "The name has to be at least 2 characters long", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname is missing")]
        [StringLength(256, ErrorMessage = "The name has to be at least 2 characters long", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress is missing")]
        [StringLength(256, ErrorMessage = "The Adress has to be at least 2 characters long", MinimumLength = 2)]
        public string Adress { get; set; }

        [Display(Name = "Postalcode")]
        [Required(ErrorMessage = "Postalcode is missing")]
        [StringLength(5, ErrorMessage = "The postalcode has to be 5 characters long, e.g. 12345", MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is missing")]
        [StringLength(256, ErrorMessage = "The name of the city has to be at least 2 characters long", MinimumLength = 2)]
        public string City { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is missing")]
        [EmailAddress(ErrorMessage = "The email adress must be valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You have to type in a password")]
        [StringLength(256, ErrorMessage = "The password has to be at least 8 characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You have to confirm the password")]
        [Compare("Password", ErrorMessage = "The password and confirmed password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

    }
}
