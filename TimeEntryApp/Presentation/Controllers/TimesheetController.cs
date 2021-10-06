using BL.Logics;
using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class TimesheetController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly TimesheetBL _timesheetBL;

        public TimesheetController(ApplicationDbContext db,TimesheetBL timesheetBL)
        {
            this._db = db;
            this._timesheetBL = timesheetBL;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    List<Entry> Entries = new List<Entry>();

        //    var paticularUserId  = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value; 

        //    if(!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    } 

        //    var result = await _timesheetBL.


        //    return View();
        //}

        //
        //GET : /Timesheet/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST : /Timesheet/Create
        [HttpPost]
        public async Task<IActionResult> Create(Entry entry)
        {   
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _timesheetBL.CreateEntry(entry);
            return View(entry);
        }

        
        [HttpGet]
        public IActionResult BreakIndex()
        {
            IEnumerable<Break> breakList = _db.Breaks;

            return View(breakList);
        }

        //
        //GET: /Timesheet/AddBreak
        public IActionResult AddBreak()
        {
            return View();
        }

        //POST: /Timesheet/AddBreak
        [HttpPost]
        public async Task<IActionResult> AddBreak(Break @break)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _timesheetBL.CreateBreak(@break);
            return View(@break);
        }


        public IActionResult ViewDetails()
        {
            return View();
        }

        //DELETE: /Timesheet/delete/:id
        public IActionResult DeleteEntry(int? id)
        {
            _timesheetBL.DeleteEntry(id);
            return RedirectToAction("Index");

        } 


    }
}
