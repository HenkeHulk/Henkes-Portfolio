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
            var modelProduct = new ProductViewModel();
            var modelProds = new List<ProductViewModel>();
            foreach (var prod in products)
            {
                modelProduct.Id = prod.Id;
                modelProduct.Title = prod.Title;
                modelProduct.Price = prod.Price;
                modelProduct.ItemsInStock = prod.ItemsInStock;
                modelProduct.VendorId = prod.VendorId;
                modelProduct.DepartmentId = prod.DepartmentId;

                modelProds.Add(modelProduct);
            }
            IndexViewModel model = new IndexViewModel()
            {
                Products = modelProds,
                Department = deptHelper.FindDepartment(modelProduct.DepartmentId),
                Vendor = vendorHelper.FindVendor(modelProduct.VendorId)
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var vendors = vendorHelper.AllVendors();
            var departments = deptHelper.AllDepartments();
            List<SelectListItem> vendorListItems = new List<SelectListItem>();
            List<SelectListItem> deptListItems = new List<SelectListItem>();
            foreach (var vendor in vendors)
            {
                var selectedVendor = new SelectListItem()
                {
                    Value = vendor.Id.ToString(),
                    Text = vendor.Name
                };
                vendorListItems.Add(selectedVendor);
            }

            foreach (var dept in departments)
            {
                var selectedDept = new SelectListItem()
                {
                    Value = dept.Id.ToString(),
                    Text = dept.Name
                };
                deptListItems.Add(selectedDept);
            }


            var modelProduct = new AddProductViewModel()
            {
                Vendors = vendorListItems,
                Departments = deptListItems
            }; 

            return View(modelProduct);
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel product)
        {
            var vendorsList = new List<VendorViewModel>();
            vendorsList = vendorHelper.AllVendors();
            

            var modelProduct = new ProductViewModel()
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                ItemsInStock = product.ItemsInStock,
                DepartmentId = product.SelectedDepartmentId,
                VendorId = product.SelectedDepartmentId
            };
            prodHelper.InsertOrUpdate(modelProduct);
            return RedirectToAction("Index");
        }

    }
}