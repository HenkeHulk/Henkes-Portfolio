using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;

namespace Portfolio.Repository.Repositories
{
    public class VendorRepository : IVendor
    {
        public IQueryable<Vendor> All
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Vendor entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Vendor Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Vendor entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
