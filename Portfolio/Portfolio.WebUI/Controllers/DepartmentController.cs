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
                Name = dept.Name,
                ImagePath = dept.ImagePath
            };
            deptHelper.InsertOrUpdate(addDept);
            return Redirect("~/Admin/Index");
        }

        public ActionResult Index(int Id)
        {
            var dept = deptHelper.FindDepartment(Id);
            var products = prodHelper.AllProducts().Where(x => x.DepartmentId == dept.Id).ToList();
            var modelProds = new List<ProductViewModel>();
            var modelProduct = new ProductViewModel();

            foreach (var prod in products)
            {
                modelProduct = new ProductViewModel()
                {
                    Id = prod.Id,
                    Title = prod.Title,
                    Price = prod.Price,
                    ItemsInStock = prod.ItemsInStock       
                };
                modelProds.Add(modelProduct);
            }
            DepartmentIndexViewModel model = new DepartmentIndexViewModel()
            {
                Id = dept.Id,
                Name = dept.Name,
                Products = modelProds
            };

            return View(model);
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
                ImagePath = dept.ImagePath,
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
                Name = deptDetails.Name,
                ImagePath = deptDetails.ImagePath
            };
            deptHelper.InsertOrUpdate(dept);
            return Redirect("~/Admin/Index");
        }

        public ActionResult DeleteDepartment(int Id)
        {
            var delDept = deptHelper.FindDepartment(Id);
            deptHelper.DeleteDepartment(delDept.Id);
            return Redirect("~/Admin/Index");
        }
    }
}