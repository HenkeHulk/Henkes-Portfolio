using Portfolio.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DataAccessLayer.DomainClasses;
using Portfolio.DataAccessLayer;

namespace Portfolio.Repository.Repositories
{
    public abstract class CatalogRepository : ICatalog
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        public IQueryable<Catalog> All
        {
            get
            {
                return dbContext.Catalog;
            }
        }

        public void Delete(Catalog entity)
        {
            var delCatalog = Find(entity.Id);
            dbContext.Catalog.Remove(delCatalog);
            Save();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Catalog Find(int id)
        {
            return dbContext.Catalog.Find(id);
        }

        public void InsertOrUpdate(Catalog entity)
        {
            var existingCatalog = All.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingCatalog == null)
            {
                dbContext.Catalog.Add(entity);
            }
            else
            {
                existingCatalog.Id = entity.Id;
                existingCatalog.Name = entity.Name;
                existingCatalog.Departments = entity.Departments;
                existingCatalog.Product = entity.Product;
                existingCatalog.Vendors = entity.Vendors;
            }
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
