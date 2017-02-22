using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Models
{
    public class DepartmentDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}