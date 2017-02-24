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
            List<Product> SweDProds = new List<Product>();
            List<Vendor> Vendors = new List<Vendor>();
            var contactHH = new Contact()
            {
                FirstName = "Henrik",
                SureName = "Häggbom",
                EmailAddress = "henrik@henriksspelbutik.se",
                PhoneNumber = "08-1234567",
                VendorId = 1
            };
            var contactAA = new Contact()
            {
                FirstName = "Anders",
                SureName = "Andersson",
                EmailAddress = "anders@swedroid.se",
                PhoneNumber = "08-1234567",
                VendorId = 2
            };
            
            Vendors.Add(new Vendor() { Name = "Henriks Spelbutik", Country = "Sweden", City = "Sollentuna", Products = Products, Street = "Spelvägen 1", PostalCode = "19100", ContactId=1, ImagePath="HH-Logo-black.png" });
            Vendors.Add(new Vendor() { Name = "SweDroid", Country = "Sweden", City = "Stockholm", Products = SweDProds, Street = "Ringvägen 25", PostalCode = "11800", ContactId = 2, ImagePath="Android-Company-Logo.jpg" });
            Products.Add(new Product() { DepartmentId = 3, VendorId = 1, ItemsInStock = 2, Title = "NHL 17", Price = 699 });
            Products.Add(new Product() { DepartmentId = 3, VendorId = 1, ItemsInStock = 3, Title = "FIFA 17", Price = 699 });
            Products.Add(new Product() { DepartmentId = 3, VendorId = 1, ItemsInStock = 7, Title = "Dirt Rally", Price = 699 });
            Products.Add(new Product() { DepartmentId = 3, VendorId = 1, ItemsInStock = 5, Title = "Lego: The Force Awakens", Price = 699 });
            SweDProds.Add(new Product() { DepartmentId = 5, VendorId = 2, ItemsInStock = 3, Title = "SmartPhone S", Price = 2500 });
            SweDProds.Add(new Product() { DepartmentId = 5, VendorId = 2, ItemsInStock = 3, Title = "SmartPhone", Price = 2000 });
            SweDProds.Add(new Product() { DepartmentId = 6, VendorId = 2, ItemsInStock = 7, Title = "Smartwatch", Price = 2000 });
            SweDProds.Add(new Product() { DepartmentId = 6, VendorId = 2, ItemsInStock = 6, Title = "Smartwatch S", Price = 2500 });
            Contacts.Add(contactHH);
            Contacts.Add(contactAA);
            Departments.Add(new Department() { Name = "Computers & Tablets", ImagePath= "pcvs_brand_microsoft_short-tile_v4d._CB274378532_.jpg" });
            Departments.Add(new Department() { Name = "Headphones", ImagePath="headphones.jpg"});
            Departments.Add(new Department() { Name = "Video Games", ImagePath="video-games.jpg" });
            Departments.Add(new Department() { Name = "TV & Audio", ImagePath="tvandvideo.png" });
            Departments.Add(new Department() { Name = "Cellphones & Accessories", ImagePath="cellphones_accessories.jpg" });
            Departments.Add(new Department() { Name = "Wearable electronics", ImagePath="wearable_electronics.jpeg" });
            Departments.Add(new Department() { Name = "Camera, Photo & Video", ImagePath="camera_photo.jpg" });

            foreach (var vendor in Vendors)
                context.Vendors.Add(vendor);

            foreach (var product in Products)
                context.Products.Add(product);

            foreach (var product in SweDProds)
                context.Products.Add(product);

            foreach (var _contact in Contacts)
                context.Contacts.Add(_contact);

            foreach (var department in Departments)
                context.Departments.Add(department);

            base.Seed(context);
        }
    }
}
