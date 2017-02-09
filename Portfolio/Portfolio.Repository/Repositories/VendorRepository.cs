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
    public class VendorRepository : IVendor
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        public IQueryable<Vendor> All
        {
            get
            {
                return dbContext.Vendors;
            }
        }

        public void Delete(Vendor entity)
        {
            var delVendor = Find(entity.Id);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Vendor Find(int id)
        {
            return dbContext.Vendors.Find(id);
        }

        public void InsertOrUpdate(Vendor entity)
        {
            var existingVendor = All.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingVendor == null)
            {
                dbContext.Vendors.Add(entity);
            }
            else
            {
                existingVendor.Id = entity.Id;
                existingVendor.Name = entity.Name;
                existingVendor.Products = entity.Products;
                existingVendor.Street = entity.Street;
                existingVendor.PostalCode = entity.PostalCode;
                existingVendor.City = entity.City;
                existingVendor.Country = entity.Country;
                existingVendor.ContactId = entity.ContactId;
            }
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
