using DA.Data;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class TimesheetRepository : Repository<Entry>
    {
        private readonly ApplicationDbContext _db;

        public TimesheetRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }

        public ApplicationDbContext Db => _db;
    }
}
