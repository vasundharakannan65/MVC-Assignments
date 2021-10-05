﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    public class EntryBreak
    {
        public int EntryID { get; set; }
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime InTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime OutTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime BreakIn { get; set; }

        [DataType(DataType.Time)]
        public DateTime BreakOut { get; set; }
    }
}
