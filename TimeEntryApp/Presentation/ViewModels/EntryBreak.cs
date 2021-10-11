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

        public DateTime Date { get; set; }

        public TimeSpan InTime { get; set; }

        public TimeSpan OutTime { get; set; }

        public TimeSpan TotalWorkingTime { get; set; }

        public IList<Entry> Entries { get; set; }

        public int BreakID { get; set; }


        public TimeSpan BreakIn { get; set; }


        public TimeSpan BreakOut { get; set; }


        public TimeSpan TotalBreakTime { get; set; }

        public IList<Break> Breaks { get; set; }
    }
}
