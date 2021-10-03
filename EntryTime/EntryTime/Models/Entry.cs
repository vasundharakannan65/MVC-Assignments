using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntryTime.Models
{
    public class Entry
    {
        [Key]
        public int EntryID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime OutTime { get; set; }

        [Display(Name = "User Id")]
        public ICollection<Break> Break { get; set; }



    }
}
