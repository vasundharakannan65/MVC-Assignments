using DA.Access;
using DA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logics
{
    public class AccountBL
    {
        private readonly AccountDA _accountDA;
        public AccountBL(AccountDA accountDA)
        {
            this._accountDA = accountDA;
        }
        public Task<IdentityResult> CreateUser(Register register)
        {
            var result = _accountDA.CreateUser(register);
            return result;
        }

        public Task<SignInResult> CheckUser(Login login)
        {
            var result = _accountDA.CheckUser(login);
            return result;
        }
    }
}
