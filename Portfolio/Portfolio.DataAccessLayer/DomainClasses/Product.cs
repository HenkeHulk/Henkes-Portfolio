namespace Portfolio.DataAccessLayer.DomainClasses
{
    public class Product
    {
        public int Id { get; set; }

        public int CatalogId { get; set; }

        public int DepartmentId { get; set; }

        public int VendorId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public Department Department { get; set; }

        public int ItemsInStock { get; set; }

        public Vendor Vendor { get; set; }
    }
}