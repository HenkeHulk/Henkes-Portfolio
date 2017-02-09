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
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }

    public class CatalogDbContextInitializer : DropCreateDatabaseIfModelChanges<CatalogDbContext>
    {
        protected override void Seed(CatalogDbContext context)
        {
            List<Contact> Contacts = new List<Contact>();
            List<Department> Departments = new List<Department>();
            List<Product> Products = new List<Product>();
            List<Vendor> Vendors = new List<Vendor>();
            var contact = new Contact()
            {
                FirstName = "Henrik",
                SureName = "Häggbom",
                EmailAddress = "henrik@haggbom.se",
                PhoneNumber = "08-1234567",
                VendorId = 1
            };
            var contact1 = new Contact()
            {
                FirstName = "Anders",
                SureName = "Andersson",
                EmailAddress = "anders@anderssonkott.se",
                PhoneNumber = "08-1234567",
                VendorId = 2
            };

            Vendors.Add(new Vendor() { Name = "Anderssons Kött", Country = "Sweden", City = "Stockholm", Products = Products, Street = "Slakhusgatan 1", PostalCode = "16100", ContactId=2 });
            Vendors.Add(new Vendor() { Name = "Henriks Spelbutik", Country = "Sweden", City = "Sollentuna", Products = Products, Street = "Spelvägen 1", PostalCode = "19100", ContactId=1 });
            Products.Add(new Product() { DepartmentId = 3, VendorId = 2, ItemsInStock = 2, Title = "NHL 17", Price = 699 });
            Contacts.Add(contact);
            Contacts.Add(contact1);
            Departments.Add(new Department() { Name = "Food" });
            Departments.Add(new Department() { Name = "Sports Apparel" });
            Departments.Add(new Department() { Name = "Video Games" });
            Departments.Add(new Department() { Name = "TV" });

            foreach (var vendor in Vendors)
                context.Vendors.Add(vendor);

            foreach (var product in Products)
                context.Products.Add(product);

            foreach (var _contact in Contacts)
                context.Contacts.Add(_contact);

            foreach (var department in Departments)
                context.Departments.Add(department);

            base.Seed(context);
        }
    }
}
