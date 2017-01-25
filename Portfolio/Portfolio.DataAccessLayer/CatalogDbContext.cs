using Portfolio.DataAccessLayer.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccessLayer
{
    public class CatalogDbContext:DbContext
    {
        public CatalogDbContext() : base("name=CatalogDb")
        {

        }

        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
