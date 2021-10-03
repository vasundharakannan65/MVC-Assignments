using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntryTime.Models
{
    public class Break
    {
        [Key]
        public int BreakID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BreakIn { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BreakOut { get; set; }



        [ForeignKey("Entry")]
        public int EntryID { get; set; }


    }
}
