using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Access
{
    public class AdminDA
    {
        private readonly ApplicationDbContext _db;

        public AdminDA(ApplicationDbContext db)
        {
            _db = db;
        }

        //Getting all user & entries based on date
        public IEnumerable<Entry> BasedOnDate(DateTime dateValue)
        {
            //List<ApplicationUser> Users = new();
            List<Entry> Entries = new();

            //var user = _db.ApplicationUsers.ToList();

            //foreach (ApplicationUser usr in user)
            //{
            //    List<Entry> Entries = new();
            //    _db.Entry(usr).Collection(e => e.Entries).Load();
            //    _db.Entries.Where(x => x.Date.Year == dateValue.Year && x.Date.Month == dateValue.Month && x.Date.Day == dateValue.Day);
            //    foreach (Entry ety in usr.Entries)
            //    {
            //        List<Break> breaks = new();
            //        _db.Entry(ety).Collection(item => item.Breaks).Load();
            //        foreach (Break brk in ety.Breaks)
            //        {
            //            breaks.Add(brk);
            //        }
            //        ety.Breaks = breaks;
            //        Entries.Add(ety);
            //    } 
            //    usr.Entries = 

            //}
            var entry = _db.Entries.Where(x => x.Date.Year == dateValue.Year && x.Date.Month == dateValue.Month && x.Date.Day == dateValue.Day);


                foreach (Entry ety in entry)
                {
                    List<Break> breaks = new();
                    _db.Entry(ety).Collection(item => item.Breaks).Load();
                    foreach (Break brk in ety.Breaks)
                    {
                        breaks.Add(brk);
                    }
                    ety.Breaks = breaks;
                    Entries.Add(ety);
                }
                
                return Entries;
        }
    }
}
