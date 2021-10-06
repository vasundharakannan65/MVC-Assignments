using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        //Getting particular Id entries
        public IEnumerable<Entry> GetParticularIdEntries(ApplicationUser user)
        {
            List<Entry> Entries = new();
            _db.Entry(user).Collection(item => item.Entries).Load();
            foreach (Entry entry in user.Entries)
            {
                List<Break> breaks = new();
                _db.Entry(entry).Collection(item => item.Breaks).Load();
                foreach (Break brk in entry.Breaks)
                {
                    breaks.Add(brk);
                }

                entry.Breaks = breaks;
                Entries.Add(entry);
            }

            return Entries;
        }

        //Creating entries
        public void CreateEntry(ApplicationUser user,Entry entry)
        {
            _db.Users.FirstOrDefault(x => x.Id == user.Id).Entries.Add(entry);
            _db.SaveChanges();
        }

        //creating breaks
        public void CreateBreak(ApplicationUser user,int id,Break @break)
        {
            var entry = _db.Entries.FirstOrDefault(x => x.EntryID == id);
            entry.Breaks.Add(@break);
            _db.SaveChanges();
        } 

        //deleting entry
        public void DeleteEntry(ApplicationUser user,int? id)
        {

            var entry = _db.Entries.FirstOrDefault(x => x.EntryID == id);
            if (entry != null)
            {
                _db.Users.FirstOrDefault(x => x.Id == user.Id).Entries.Remove(entry);
                _db.SaveChanges();

            }
        }
    }
}
