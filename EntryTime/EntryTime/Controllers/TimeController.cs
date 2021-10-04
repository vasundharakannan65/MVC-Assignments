using EntryTime.Data;
using EntryTime.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntryTime.Controllers
{
    public class TimeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TimeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Entry> entryList = _db.Entries;

            return View(entryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                _db.Entries.Add(entry);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(entry);
        }

        [HttpGet]
        public IActionResult BreakIndex()
        {
            IEnumerable<Break> breakList = _db.Breaks;

            return View(breakList);
        }

        public IActionResult AddBreak()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBreak(Break @break)
        {
            if (ModelState.IsValid)
            {
                _db.Breaks.Add(@break);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(@break);
        }


        public IActionResult ViewDetails()
        {   
            return View();
        }
    }
}
