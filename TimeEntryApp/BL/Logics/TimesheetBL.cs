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
        public void CreateBreak(int id,Break @break)
        {
            _timesheetDA.CreateBreak(id,@break);

        }

        //updating entry - Gettting ID
        public Entry UpdateEntryID(int id)
        {
            var entry = _timesheetDA.UpdateEntryID(id);
            return entry;
        }

        //updating entry - Gettting ID
        public void UpdateEntry(ApplicationUser user,Entry entry)
        {
            _timesheetDA.UpdateEntry(user,entry);

        }


        //Deleting entry
        public void DeleteEntry(ApplicationUser user,int? id)
        {
            _timesheetDA.DeleteEntry(user,id);
        }

        //Deleting break
        public void DeleteBreak(int? id)
        {
            _timesheetDA.DeleteBreak(id);
        }

        //Based on Month entries of particular user 
        public List<Entry> BasedOnMonth(ApplicationUser user,DateTime monthValue)
        {
            var result = _timesheetDA.BasedOnMonth(user, monthValue).ToList();
            return result;
        }

    }
}
