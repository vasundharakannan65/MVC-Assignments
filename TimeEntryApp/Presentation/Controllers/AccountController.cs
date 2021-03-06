using BL.Logics;
using DA.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{

    public class AccountController : Controller
    {
        private readonly AccountBL _accountBL;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(AccountBL accountBL, SignInManager<ApplicationUser> signInManager)
        {
            this._accountBL = accountBL;
            this._signInManager = signInManager;
        }

        //
        //GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        //POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CheckUser(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Timesheet");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        //
        //GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }


        //POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountBL.CreateUser(model);


                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(model);
        }

        //POST: /Account/LOGOUT
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
