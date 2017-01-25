using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;

namespace Portfolio.Repository.Repositories
{
    public class ProductRepository : IProduct
    {
        public IQueryable<Product> All
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
