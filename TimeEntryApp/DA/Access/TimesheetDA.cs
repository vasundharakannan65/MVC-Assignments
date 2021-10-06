using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Access
{
    public class TimesheetDA
    {
        private readonly ApplicationDbContext _db;

        public TimesheetDA(ApplicationDbContext db)
        {
            _db = db;
        }

        //public async Task<Entry> GetParticularIdEntries(string Id)
        //{
        //    var result = from t1 in _db.Entries
        //                 join t2 in _db.ApplicationUsers 
        //                 on t1. 

        //    var res = _db.Entry(Id).Collection(x => x.Entries).Load();
        //    //_applicationDbContext.Entry(user).Collection(x => x.EmployeeEntries).Load();

        //    return result;
        //}

        public async Task<Entry> CreateEntry(Entry entry)
        {
            await _db.Entries.AddAsync(entry);
            _db.SaveChanges();
            return entry;
        }

        public async Task<Break> CreateBreak(Break @break)
        {
            await _db.Breaks.AddAsync(@break);
            _db.SaveChanges();
            return @break;
        } 

        public void DeleteEntry(int? id)
        {
            var entry = _db.Entries.FirstOrDefault(x => x.EntryID == id);
            if (entry != null)
            {
                _db.Entries.Remove(entry);
                _db.SaveChanges();

            }
        }
    }
}
