using BL.Logics;
using DA.Data;
using DA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Employee")]
    public class TimesheetController : Controller
    {
        private readonly TimesheetBL _timesheetBL;
        private readonly UserManager<ApplicationUser> _userManager; 

        public TimesheetController(TimesheetBL timesheetBL,UserManager<ApplicationUser> userManager)
        {
            this._timesheetBL = timesheetBL;
            this._userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Dashboard(DateTime monthValue)
        {

            List<Entry> Entries = new();

            ApplicationUser user;
            //TimeSpan TotalBreakTime = new();
            //TimeSpan TotalWorkingTime = new();

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
                    Entries = _timesheetBL.BasedOnMonth(user, monthValue);

                    //foreach (var item in Entries)
                    //{
                    //    TotalWorkingTime = item.OutTime.Subtract(item.InTime);

                    //    ViewBag.EntryBag = TotalWorkingTime;

                    //    foreach (var brk in item.Breaks)
                    //    {
                    //        TotalBreakTime += brk.BreakOut.Subtract(brk.BreakIn);

                    //        ViewBag.EntryBag = TotalBreakTime;
                    //    }
                    //}
                }
            }

          
            return View(Entries);
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

        //
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
            //IEnumerable<Break> breakList = _db.Breaks;

            return View();
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
                    _timesheetBL.CreateBreak(id, @break);
                }
            }

            return View(@break);
        }


        public IActionResult ViewDetails()
        {
            return View();
        }

        //DELETE: /Timesheet/delete/:id - entry
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

        //DELETE: /Timesheet/delete/:id - break
        public async Task<IActionResult> DeleteBreak(int? id)
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
                    _timesheetBL.DeleteBreak(id);
                }
            }
            return RedirectToAction("Index");

        }

    }
}
