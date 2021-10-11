using DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        public IRepository<Entry> Entries { get; }

        public IRepository<ApplicationUser> Users { get; }

        public IRepository<Break> Breaks { get; }

        void Save();
    }
}
