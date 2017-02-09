using Portfolio.WebUI.Helpers;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentHelper deptHelper = new DepartmentHelper();
        ProductHelper prodHelper = new ProductHelper();
        VendorHelper vendHelper = new VendorHelper();

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel dept)
        {
            var addDept = new DepartmentViewModel()
            {
                Name = dept.Name
            };
            deptHelper.InsertOrUpdate(addDept);
            return Redirect("~/Admin/Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dept = deptHelper.FindDepartment(id);
            var products = prodHelper.AllProducts().Where(x => x.DepartmentId == dept.Id).ToList();
            var deptDetailsProds = new List<ProductViewModel>();
            foreach (var prod in products)
            {
                var vendor = vendHelper.FindVendor(prod.VendorId);
                var product = new ProductViewModel()
                {
                    Id = prod.Id,
                    DepartmentId = prod.DepartmentId,
                    ItemsInStock = prod.ItemsInStock,
                    Price = prod.Price,
                    Title = prod.Title,
                    Vendor = vendor,
                    VendorId = prod.VendorId
                };
                deptDetailsProds.Add(product);
            }
            var deptDetails = new DepartmentDetailsViewModel()
            {
                Id = dept.Id,
                Name = dept.Name,
                Products = deptDetailsProds
            };
            return View(deptDetails);
        }

        [HttpPost]
        public ActionResult Details(DepartmentDetailsViewModel deptDetails)
        {

            var dept = new DepartmentViewModel()
            {
                Id = deptDetails.Id,
                Name = deptDetails.Name
            };
            deptHelper.InsertOrUpdate(dept);
            return Redirect("~/Admin/Index");
        }
    }
}