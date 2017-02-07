using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Models
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public int SelectedDepartmentId { get; set; }

        public int SelectedVendorId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Vendors { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int ItemsInStock { get; set; }
    }
}