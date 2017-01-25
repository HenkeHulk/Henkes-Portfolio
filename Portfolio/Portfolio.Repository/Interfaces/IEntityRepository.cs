using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Repository.Interfaces
{
    public interface IEntityRepository<T>:IDisposable
    {
        IQueryable<T> All { get; }
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(T entity);
        void Save();
    }
}
