using DA.Data;
using DA.Interfaces;
using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _db;

        private IRepository<Entry> _entries;

        private IRepository<Break> _breaks;

        private IRepository<ApplicationUser> _users;




        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;

        }

        public IRepository<Entry> Entries => _entries ??= new Repository<Entry>(_db);

        public IRepository<ApplicationUser> Users => _users ??= new Repository<ApplicationUser>(_db);

        public IRepository<Break> Breaks => _breaks ??= new Repository<Break>(_db);




        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _db.Dispose();

        }


        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
