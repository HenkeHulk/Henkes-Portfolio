using System.Collections.Generic;

namespace Portfolio.DataAccessLayer.DomainClasses
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Contact Contact { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}