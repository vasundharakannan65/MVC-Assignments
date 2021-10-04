using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntryTime.Models
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name="Email ID")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
