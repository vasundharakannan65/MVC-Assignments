using BL.Logics;
using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager; 

        public TimesheetController(ApplicationDbContext db,TimesheetBL timesheetBL,UserManager<ApplicationUser> userManager)
        {
            this._db = db;
            this._timesheetBL = timesheetBL;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return View();
        }

        //GET: /Timesheet/Index - Getting particular user id entries
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Entry> Entries = new();

            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null) 
            {
                user =  await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Entries = _timesheetBL.GetParticularIdEntries(user);
                }
            }

           
            return View(Entries);
        }


        //GET : /Timesheet/Create - create entry
        public IActionResult Create()
        {
            return View();
        }

        //POST : /Timesheet/Create - create entry
        [HttpPost]
        public async Task<IActionResult> Create(Entry entry)
        {

            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null)
            {
                user = await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _timesheetBL.CreateEntry(user,entry);
                }
            }

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
        public async Task<IActionResult> AddBreak(int id,Break @break)
        {
            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null)
            {
                user = await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _timesheetBL.CreateBreak(user, id, @break);
                }
            }

            return View(@break);
        }


        public IActionResult ViewDetails()
        {
            return View();
        }

        //DELETE: /Timesheet/delete/:id
        public async Task<IActionResult> DeleteEntry(int? id)
        {
            ApplicationUser user;

            var particularUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (particularUserId != null)
            {
                user = await this._userManager.FindByIdAsync(particularUserId);

                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _timesheetBL.DeleteEntry(user, id);
                }
            } 
            return RedirectToAction("Index");

        } 


    }
}
