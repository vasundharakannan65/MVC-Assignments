using DA.Access;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Logics
{
    public class AdminBL
    {
        private readonly AdminDA _adminDA;
        public AdminBL(AdminDA adminDA)
        {
            this._adminDA = adminDA;
        }

        //Getting all entries 
        public List<Entry> BasedOnDate(DateTime dateValue)
        {
            var result = _adminDA.BasedOnDate(dateValue).ToList();
            return result;
        }
    }
}
