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
    }
}