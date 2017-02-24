using Portfolio.WebUI.Helpers;
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

            var vendors = vendorHelper.AllVendors().ToList();
            var modelVendors = new List<VendorViewModel>();
            var modelVendor = new VendorViewModel();

            var depts = deptHelper.AllDepartments().ToList();
            var modelDepts = new List<DepartmentViewModel>();
            var modelDept = new DepartmentViewModel();

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
                modelVendor = new VendorViewModel()
                {
                    Id = vend.Id,
                    Name = vend.Name,
                    ImagePath = vend.ImagePath
                };
                modelVendors.Add(modelVendor);
            }

            foreach (var dept in depts)
            {
                modelDept = new DepartmentViewModel()
                {
                    Id = dept.Id,
                    ImagePath = dept.ImagePath,
                    Name = dept.Name
                };
                modelDepts.Add(modelDept);
            }
            var model = new IndexViewModel()
            {
                Products = modelProds,
                Departments = modelDepts,
                Vendors = modelVendors
            };

            return View(model);
        }

    }
}