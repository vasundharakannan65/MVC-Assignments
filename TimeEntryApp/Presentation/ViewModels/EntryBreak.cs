using DA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class EntryBreak
    {
        public int ID { get; set; }

        public int EntryID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime OutTime { get; set; }

        public IList<Entry> Entries { get; set; }

        public int BreakID { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BreakIn { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime BreakOut { get; set; }


        public IList<Break> Break { get; set; }
    }
}
