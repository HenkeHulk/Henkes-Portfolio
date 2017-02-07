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
    public class ProductRepository : IProduct
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        public IQueryable<Product> All
        {
            get
            {
                return dbContext.Products;
            }
        }

        public void Delete(Product entity)
        {
            var delProd = Find(entity.Id);
            dbContext.Products.Remove(delProd);
            Save();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Product Find(int id)
        {
            return dbContext.Products.Find(id);
        }

        public void InsertOrUpdate(Product entity)
        {
            var existingProd = All.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingProd == null)
            {
                dbContext.Products.Add(entity);
            }
            else
            {
                existingProd.Id = entity.Id;
                existingProd.DepartmentId = entity.DepartmentId;
                existingProd.VendorId = entity.VendorId;
                existingProd.Title = entity.Title;
                existingProd.Price = entity.Price;
                existingProd.ItemsInStock = entity.ItemsInStock;
            }
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
