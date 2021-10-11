using DA.Data;
using DA.Interfaces;
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
        //private readonly IUnitofWork _unitofWork;

        //public IUnitofWork UnitofWork => _unitofWork;

        public TimesheetDA(ApplicationDbContext db)
        {
            this._db = db;
            //this._unitofWork = unitofWork;
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

        //Getting particular Id entries based on month
        public IEnumerable<Entry> BasedOnMonth(ApplicationUser user,DateTime monthValue)
        {
            List<Entry> Entries = new();

            _db.Entry(user).Collection(item => item.Entries).Load();

            var entry = user.Entries.Where(x => x.Date.Year == monthValue.Year && x.Date.Month == monthValue.Month);

            foreach (Entry ety in entry)
            {
                List<Break> breaks = new();

                _db.Entry(ety).Collection(item => item.Breaks).Load();

                foreach(Break brk in ety.Breaks)
                {
                    breaks.Add(brk);
                }
                ety.Breaks = breaks;

                Entries.Add(ety);
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
        public void CreateBreak(int id,Break @break)
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

        //deleting entry
        public void DeleteBreak(int? id)
        {

            var brk = _db.Breaks.FirstOrDefault(x => x.BreakID == id);
            if (brk != null)
            {
                _db.Breaks.Remove(brk);
                _db.SaveChanges();

            }
        }
    }
}
