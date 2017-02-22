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
    public class DepartmentRepository : IDepartment
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        public IQueryable<Department> All
        {
            get
            {
                return dbContext.Departments;
            }
        }

        public void Delete(Department entity)
        {
            var delDept = Find(entity.Id);
            dbContext.Departments.Remove(delDept);
            Save();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public Department Find(int id)
        {
            return dbContext.Departments.Find(id);
        }

        public void InsertOrUpdate(Department entity)
        {
            var existingDept = All.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingDept == null)
            {
                dbContext.Departments.Add(entity);
            }
            else
            {
                existingDept.Id = entity.Id;
                existingDept.Name = entity.Name;
                existingDept.ImagePath = entity.ImagePath;
            }
            Save();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
