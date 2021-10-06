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

        public IList<Entry> Entries { get; set; }

        public IList<Break> Break { get; set; }
    }
}
