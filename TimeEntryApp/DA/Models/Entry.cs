using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
{
    public class Entry
    {
        public Entry()
        {
            Breaks = new List<Break>();
        }

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


        public ICollection<Break> Breaks { get; set; } 

        public ApplicationUser ApplicationUser { get; set; }


    }
}
