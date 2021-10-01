using DA.Access;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO.ViewModels;

namespace BL
{
    public class AccountBL
    {
        private readonly AccountDA _accountDA;
        public AccountBL(AccountDA accountDA)
        {
            this._accountDA = accountDA;
        }
        public Task<IdentityResult> CreateUser(RegisterViewModel registerViewModel)
        {
            var result = _accountDA.CreateUser(registerViewModel);
            return result;
        }

        public Task<SignInResult> CheckUser(LoginViewModel loginViewModel)
        {
            var result = _accountDA.CheckUser(loginViewModel);

            return result;
        }
    }
}
