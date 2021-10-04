using DA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Access
{
    public class AccountDA
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountDA(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }


        public async Task<IdentityResult> CreateUser(Register register)
        {
            var user = new IdentityUser
            {
                Email = register.Email
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            return result;
        }

        public async Task<SignInResult> CheckUser(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(
                 user.Email, login.Password, login.RememberMe, false);

                return result;
            }

            var res = SignInResult.Failed;
            return res;
        }
    }
}
