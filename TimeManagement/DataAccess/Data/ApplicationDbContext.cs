using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new ApplicationConfig();
                OpsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                OpsBuilder.UseSqlServer(Settings.SqlConnectionString);
                DbOptions = OpsBuilder.Options;
            }

            public DbContextOptionsBuilder<ApplicationDbContext> OpsBuilder { get; set; }
            public DbContextOptions<ApplicationDbContext> DbOptions { get; set; }
            private ApplicationConfig Settings { get; set; }
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}
