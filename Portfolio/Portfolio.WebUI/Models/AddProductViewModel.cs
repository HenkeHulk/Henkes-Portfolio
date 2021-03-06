﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.WebUI.Models
{
    public class AddProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Department")]
        public int SelectedDepartmentId { get; set; }

        [Display(Name = "Vendor")]
        public int SelectedVendorId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Vendors { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int ItemsInStock { get; set; }
    }
}