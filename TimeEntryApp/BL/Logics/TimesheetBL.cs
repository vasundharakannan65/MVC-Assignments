using DA.Access;
using DA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logics
{
    public class TimesheetBL
    {
        private readonly TimesheetDA _timesheetDA;

        public TimesheetBL(TimesheetDA timesheetDA)
        {
            this._timesheetDA = timesheetDA;
        }

        public List<Entry> GetParticularIdEntries(ApplicationUser user)
        {
            var result =  _timesheetDA.GetParticularIdEntries(user).ToList();
            return result; 
        }

        public async Task<Entry> CreateEntry(Entry entry)
        {
            var result = await _timesheetDA.CreateEntry(entry);
            return result;
        }

        public async Task<Break> CreateBreak(Break @break)
        {
            var result = await _timesheetDA.CreateBreak(@break);
            return result;
        }

        public void DeleteEntry(int? id)
        {
            _timesheetDA.DeleteEntry(id);
        }

    }
}
