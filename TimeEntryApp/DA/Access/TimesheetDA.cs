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

        public IEnumerable<Entry> GetParticularIdEntries(ApplicationUser user)
        {
            List<Entry> Entries = new List<Entry>();
            _db.Entry(user).Collection(item => item.Entries).Load();
            foreach (Entry entry in user.Entries)
            {
                List<Break> breaks = new List<Break>();
                _db.Entry(entry).Collection(em => em.Breaks).Load();
                foreach (Break b in entry.Breaks)
                {
                    breaks.Add(b);
                }

                entry.Breaks = breaks;
                Entries.Add(entry);
            }

            return Entries;
        }

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
