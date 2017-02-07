﻿using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ProductHelper prodHelper = new ProductHelper();
        VendorHelper vendorHelper = new VendorHelper();
        DepartmentHelper deptHelper = new DepartmentHelper();

        public ActionResult Index()
        {
            var products = prodHelper.AllProducts().ToList();
            var modelProds = new List<ProductViewModel>();
            var modelProduct = new ProductViewModel();

            foreach (var prod in products)
            {
                var deptById = deptHelper.FindDepartment(prod.DepartmentId);
                var vendById = vendorHelper.FindVendor(prod.VendorId);
                modelProduct = new ProductViewModel()
                {
                    Id = prod.Id,
                    Title = prod.Title,
                    Price = prod.Price,
                    ItemsInStock = prod.ItemsInStock,
                    VendorId = prod.VendorId,
                    DepartmentId = prod.DepartmentId,
                    Department = deptById,
                    Vendor = vendById      
                };
                modelProds.Add(modelProduct);
            }
            var model = new IndexViewModel()
            {
                Products = modelProds
            };

            return View(model);
        }

    }
}