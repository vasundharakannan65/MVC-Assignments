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


        public DateTime Date { get; set; }


        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }


        [DataType(DataType.Time)]
        public DateTime OutTime { get; set; }

        [Display(Name = "User Id")]
        public ICollection<Break> Breaks { get; set; } 


    }
}
