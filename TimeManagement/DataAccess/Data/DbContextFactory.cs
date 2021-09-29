using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            ApplicationConfig appConfig = new ApplicationConfig();
            var opsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            opsBuilder.UseSqlServer(appConfig.SqlConnectionString);
            return new ApplicationDbContext(opsBuilder.Options);
        }
    }
}
