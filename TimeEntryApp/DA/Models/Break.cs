using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Models
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


        public Entry Entry { get; set; }

    }
}
