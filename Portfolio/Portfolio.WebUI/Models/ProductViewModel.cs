namespace Portfolio.WebUI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int VendorId { get; set; }

        public DepartmentViewModel Department { get; set; }

        public VendorViewModel Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int ItemsInStock { get; set; }
    }
}