using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntryTime.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DOB { get; set; }
    }
}
