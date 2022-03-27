using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OmnivusV1.Models.Data
{
    public class AppUser : IdentityUser
    {   
        [Required, PersonalData]
        public string FirstName { get; set; }

        [Required, PersonalData]
        public string LastName { get; set; }

        [Required, PersonalData]
        public string Adress { get; set; }

        [Required, PersonalData]
        public string PostalCode { get; set; }

        [Required, PersonalData]
        public string City { get; set; }
    }
}
