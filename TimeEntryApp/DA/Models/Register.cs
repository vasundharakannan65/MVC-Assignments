using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{

    public class Register
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirm password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }

    }
}
