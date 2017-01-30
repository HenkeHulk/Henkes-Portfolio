using Portfolio.DataAccessLayer.DomainClasses;
using System.Collections.Generic;
using System.Data.Entity;

namespace Portfolio.DataAccessLayer
{
    public class CatalogDbContextInitializer : DropCreateDatabaseAlways<CatalogDbContext>
    {
        CatalogDbContext dbContext = new CatalogDbContext();
        protected override void Seed(CatalogDbContext context)
        {
            List<Catalog> Catalogs = new List<Catalog>();
            List<Contact> Contacts = new List<Contact>();
            List<Department> Departments = new List<Department>();
            List<Product> Products = new List<Product>();
            List<Vendor> Vendors = new List<Vendor>();

            //Vendors.Add(new Vendor() { Name="Anderssons Kött", Country="Sweden", City="Stockholm", Products=Products, Street="Slakhusgatan 1", PostalCode="16100", Contact= new Contact() { FirstName = "Anders", SureName = "Andersson", EmailAddress = "anders@andersson.se", PhoneNumber = "08-1234568", VendorId = 1 } });
            //Products.Add(new Product() { CatalogId=1, DepartmentId=1, Department=new Department() { Name="Spel" }, ItemsInStock=2, Title="NHL 17", Price=699, Vendor=new Vendor() { Name="Henkes Spelbutik", City="Sollentuna", Country="Sweden", Street="Spelvägen 5", PostalCode="19274", Products=Products} });
            //Contacts.Add(new Contact() { FirstName = "Henrik", SureName = "Häggbom", EmailAddress = "henrik@haggbom.se", PhoneNumber = "08-1234567", VendorId = 1 });
            //Departments.Add(new Department() { Name="Food" });
            //Departments.Add(new Department() { Name="Sports Apparel" });
            //Catalogs.Add(new Catalog() { Name="Henkes Katalog", Product=Products, Departments=Departments, Vendors=Vendors });

            //foreach (var vendor in Vendors)
            //    dbContext.Vendors.Add(vendor);

            //foreach (var product in Products)
            //    dbContext.Products.Add(product);

            //foreach (var contact in Contacts)
            //    dbContext.Contacts.Add(contact);

            //foreach (var department in Departments)
            //    dbContext.Departments.Add(department);

            //foreach (var catalog in Catalogs)
            //    dbContext.Catalog.Add(catalog);



            base.Seed(context);
        }
    }
}