using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class VendorController : Controller
    {
        VendorHelper vendorHelper = new VendorHelper();
        ProductHelper prodHelper = new ProductHelper();
        ContactHelper contactHelper = new ContactHelper();

        [HttpGet]
        public ActionResult AddVendor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVendor(VendorViewModel vendor)
        {
            var _vendor = new VendorViewModel()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                City = vendor.City,
                Country = vendor.Country,
                PostalCode = vendor.PostalCode,
                Street = vendor.Street
            };
            vendorHelper.InsertOrUpdate(_vendor);
            return Redirect("~/Admin/Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var vendor = vendorHelper.FindVendor(id);
            var products = prodHelper.AllProductsByVendorId(id);
            var contact = contactHelper.FindContactByVendorId(id);
            VendorViewModel model = new VendorViewModel()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Street = vendor.Street,
                PostalCode = vendor.PostalCode,
                City = vendor.City,
                Country = vendor.Country,
                Contact = contact,
                Products = products
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Details(VendorViewModel vendor)
        {
            var prodList = new List<ProductViewModel>();
            prodList = prodHelper.AllProductsByVendorId(vendor.Id);

            if (vendor.Contact != null)
            {
                var modelVendor = new VendorViewModel()
                {
                    Id = vendor.Id,
                    Name = vendor.Name,
                    Products = prodList,
                    Street = vendor.Street,
                    PostalCode = vendor.PostalCode,
                    City = vendor.City,
                    Country = vendor.Country,
                    Contact = vendor.Contact
                };
                vendorHelper.InsertOrUpdate(modelVendor);
            }
            else
            {
                var modelVendor = new VendorViewModel()
                {
                    Id = vendor.Id,
                    Name = vendor.Name,
                    Products = prodList,
                    Street = vendor.Street,
                    PostalCode = vendor.PostalCode,
                    City = vendor.City,
                    Country = vendor.Country
                };
                vendorHelper.InsertOrUpdate(modelVendor);
            }
            
            return Redirect("~/Admin/Index");
        }
    }
}