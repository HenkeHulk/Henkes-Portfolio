using System.Collections.Generic;

namespace Portfolio.WebUI.Models
{
    public class VendorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ContactId { get; set; }

        public ContactViewModel Contact { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}