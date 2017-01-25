using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;

namespace Portfolio.Repository.Repositories
{
    public class DepartmentRepository : IDepartment
    {
        public IQueryable<Department> All
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Department Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Department entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
