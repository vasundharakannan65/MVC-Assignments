using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DA.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public ApplicationUser()
        {
            Entries = new List<Entry>();
        }

        public IList<Entry> Entries { get; set; }

    }
}
