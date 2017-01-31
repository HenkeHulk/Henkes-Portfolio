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
            Database.SetInitializer(new CatalogDbContextInitializer());
        }

        public DbSet<Catalog> Catalog { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }

    public class CatalogDbContextInitializer : DropCreateDatabaseIfModelChanges<CatalogDbContext>
    {
        protected override void Seed(CatalogDbContext context)
        {
            List<Catalog> Catalogs = new List<Catalog>();
            List<Contact> Contacts = new List<Contact>();
            List<Department> Departments = new List<Department>();
            List<Product> Products = new List<Product>();
            List<Vendor> Vendors = new List<Vendor>();

            Vendors.Add(new Vendor() { Name = "Anderssons Kött", Country = "Sweden", City = "Stockholm", Products = Products, Street = "Slakhusgatan 1", PostalCode = "16100" });
            Products.Add(new Product() { CatalogId = 1, DepartmentId = 1, VendorId = 1, ItemsInStock = 2, Title = "NHL 17", Price = 699 });
            Contacts.Add(new Contact() { FirstName = "Henrik", SureName = "Häggbom", EmailAddress = "henrik@haggbom.se", PhoneNumber = "08-1234567", VendorId = 1 });
            Departments.Add(new Department() { Name = "Food" });
            Departments.Add(new Department() { Name = "Sports Apparel" });
            Catalogs.Add(new Catalog() { Name = "Henkes Katalog", Product = Products, Departments = Departments, Vendors = Vendors });

            foreach (var vendor in Vendors)
                context.Vendors.Add(vendor);

            foreach (var product in Products)
                context.Products.Add(product);

            foreach (var contact in Contacts)
                context.Contacts.Add(contact);

            foreach (var department in Departments)
                context.Departments.Add(department);

            foreach (var catalog in Catalogs)
                context.Catalog.Add(catalog);



            base.Seed(context);
        }
    }
}
