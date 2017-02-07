using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class AdminController : Controller
    {
        ProductHelper prodHelper = new ProductHelper();
        VendorHelper vendorHelper = new VendorHelper();
        DepartmentHelper deptHelper = new DepartmentHelper();
        
        public ActionResult Index()
        {
            var products = prodHelper.AllProducts().ToList();
            var modelProds = new List<ProductViewModel>();
            var modelProduct = new ProductViewModel();

            var vendors = vendorHelper.AllVendors().ToList();
            var modelVendors = new List<VendorViewModel>();
            var modelvendor = new VendorViewModel();

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
            foreach (var vend in vendors)
            {
                modelvendor = new VendorViewModel()
                {
                    Id = vend.Id,
                    City = vend.City,
                    Country = vend.Country,
                    Name = vend.Name,
                    PostalCode = vend.PostalCode,
                    Street = vend.Street
                };
                modelVendors.Add(modelvendor);
            }

            var model = new AdminIndexViewModel()
            {
                Vendors = modelVendors,
                Products = modelProds
            };

            return View(model);
        }

        

        
    }
}