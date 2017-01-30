using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Models
{
    public class IndexViewModel
    {
        public string Name { get; set; }

        public List<DepartmentViewModel> Departments { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public List<VendorViewModel> Vendors { get; set; }

        public DepartmentViewModel Department { get; set; }

        public VendorViewModel Vendor { get; set; }
    }
}