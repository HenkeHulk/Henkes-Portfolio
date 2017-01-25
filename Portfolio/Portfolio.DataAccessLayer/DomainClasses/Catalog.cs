using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccessLayer.DomainClasses
{
    public class Catalog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Product> Product { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }

        public IEnumerable<Department> Departments { get; set; }

    }
}
