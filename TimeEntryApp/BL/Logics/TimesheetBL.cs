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

        //Getting particular id entries
        public List<Entry> GetParticularIdEntries(ApplicationUser user)
        {
            var result =  _timesheetDA.GetParticularIdEntries(user).ToList();
            return result; 
        }

        //Creating Entry
        public void CreateEntry(ApplicationUser user,Entry entry)
        {
            _timesheetDA.CreateEntry(user,entry);
        }

        //Creating Break
        public void CreateBreak(ApplicationUser user,int id,Break @break)
        {
            _timesheetDA.CreateBreak(user,id,@break);

        }

        //Deleting entry
        public void DeleteEntry(ApplicationUser user,int? id)
        {
            _timesheetDA.DeleteEntry(user,id);
        }

    }
}
