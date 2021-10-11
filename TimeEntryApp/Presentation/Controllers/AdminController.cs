using BL.Logics;
using DA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AdminBL _adminBL;

        public AdminController(RoleManager<IdentityRole> roleManager,AdminBL adminBL)
        {
            this._roleManager = roleManager;
            this._adminBL = adminBL;
        }

        [HttpGet]
        public IActionResult Index(DateTime dateValue)
        {

            List<Entry> Entries = new();

            if (!ModelState.IsValid)
            {
                 return RedirectToAction("Index");
            }
            else
            {
                Entries = _adminBL.BasedOnDate(dateValue);
            }

            return View(Entries);
        }

       
        //GET: /Account/CreateRole
        public IActionResult CreateRole()
        {
            return View();
        }

        //POST: /Account/CreateRole
        [HttpPost]
        public async Task<IActionResult> CreateRole(ProjectRole role)
        {
            var roleExist = await this._roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
               await this._roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }
    }
}
