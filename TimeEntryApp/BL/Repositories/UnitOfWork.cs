﻿using DA.Data;
using DA.IRepositories;
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

        //private IRepository<Dish> _dishes;

        public UnitofWork(ApplicationDbContext db)
        {
            _db = db;

        }

        //public IRepository<Dish> Dishes => _dishes ??= new Repository<Dish>(_db);

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
