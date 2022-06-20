using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpendControl.Models
{
    public class User : IdentityUser
    {
        

        [Required]
        public string FullName { get; set; }

        [Required]
        public override string PhoneNumber { get; set; }


    }
}
