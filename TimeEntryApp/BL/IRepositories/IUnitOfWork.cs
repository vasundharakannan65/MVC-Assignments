using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.IRepositories
{
    public interface IUnitofWork : IDisposable
    {
        //public IRepository<Dish> Dishes { get; }

        void Save();
    }
}
