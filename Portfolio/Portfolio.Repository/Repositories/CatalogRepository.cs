using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;

namespace Portfolio.Repository.Repositories
{
    public class CatalogRepository : ICatalog
    {
        public IQueryable<Catalog> All
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Catalog Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
