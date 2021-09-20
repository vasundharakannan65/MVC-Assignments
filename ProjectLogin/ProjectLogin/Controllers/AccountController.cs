using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectLogin.Data;
using ProjectLogin.Models;
using ProjectLogin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Http;

namespace ProjectLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDNTCaptchaValidatorService _validatorService;

        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IDNTCaptchaValidatorService validatorService) 
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _validatorService = validatorService;
        }

        //Login
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateDNTCaptcha(
            ErrorMessage = "Please Enter Valid Captcha",
            CaptchaGeneratorLanguage = Language.English,
            CaptchaGeneratorDisplayMode = DisplayMode.ShowDigits)]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null && (_validatorService.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits)))
                {
                    var result = await _signInManager.PasswordSignInAsync(user.Email, loginViewModel.Password,
                            loginViewModel.RememberMe, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            ModelState.AddModelError("", "Please Enter Valid Captcha.");
            ModelState.AddModelError("", "Invalid login");

            return View(loginViewModel);
        }


        //Register
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = true

                };

                var userObj = await _userManager.FindByEmailAsync(model.Email);

                if (userObj == null)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                }

            }


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }


    }

}
