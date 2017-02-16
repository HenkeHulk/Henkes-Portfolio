using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductHelper prodHelper = new ProductHelper();
        VendorHelper vendorHelper = new VendorHelper();
        DepartmentHelper deptHelper = new DepartmentHelper();

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var product = prodHelper.FindProductById(Id);
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


            var modelProduct = new ProductDetailsViewModel()
            {
                SelectedDepartmentId = product.DepartmentId,
                SelectedVendorId = product.VendorId,
                Id = product.Id,
                Price = product.Price,
                ItemsInStock = product.ItemsInStock,
                Title = product.Title,
                Vendors = vendorListItems,
                Departments = deptListItems
            };

            return View(modelProduct);
        }

        [HttpPost]
        public ActionResult Details(ProductDetailsViewModel product)
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
                VendorId = product.SelectedVendorId
            };
            prodHelper.InsertOrUpdate(modelProduct);
            return Redirect("~/Admin/Index");
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
                VendorId = product.SelectedVendorId
            };
            prodHelper.InsertOrUpdate(modelProduct);
            return Redirect("~/Vendor/Details/" + modelProduct.VendorId);
        }

        public ActionResult DeleteProduct(int Id)
        {
            var delProd = prodHelper.FindProductById(Id);
            prodHelper.DeleteProduct(delProd.Id);
            return Redirect("~/Vendor/Details/" + delProd.VendorId);
        }
    }
}