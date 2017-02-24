﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.WebUI.Models
{
    public class DepartmentIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}